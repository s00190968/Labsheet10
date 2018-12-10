using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoppingCart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Bicycle> bikeList;
        ObservableCollection<Bicycle> cartList;

        string[] bikeVariations;
        public decimal totalCost;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //initialise lists
            bikeList = new ObservableCollection<Bicycle>();
            cartList = new ObservableCollection<Bicycle>();


            //bike to collection
            bikeList.Add(new Bicycle("5489734", "Mountain bike", "Female", 690m));
            bikeList.Add(new Bicycle("56658876", "City bike", "Male", 300m));
            bikeList.Add(new Bicycle("55442", "Hybrid bike", "Female", 890m));
            bikeList.Add(new Bicycle("67454", "Road bike", "Female", 1200m));
            bikeList.Add(new Bicycle("5446474", "Hybrid bike", "Female", 550m));
            bikeList.Add(new Bicycle("9875", "Road bike", "Male", 740m));
            bikeList.Add(new Bicycle("12344", "Mountain bike", "Male", 490m));

            //collections to listbox
            bikesLbx.ItemsSource = bikeList;
            cartLbx.ItemsSource = cartList;

            //filter combobox
            bikeVariations = new string[] { "All", "Female", "Male" };
            filterCbx.ItemsSource = bikeVariations;
            filterCbx.SelectedIndex = 0;


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string variation = filterCbx.SelectedValue.ToString();

            if (variation == "Male")
            {
                bikesLbx.ItemsSource = FilterProducts("Male");
            }
            else if (variation == "Female")
            {
                bikesLbx.ItemsSource = FilterProducts("Female");
            }
            else
            {
                bikesLbx.ItemsSource = bikeList;
            }
        }

        ObservableCollection<Bicycle> FilterProducts(string variation)// make a temp list of the objects that have "variation" 
        {
            ObservableCollection<Bicycle> temp = new ObservableCollection<Bicycle>();

            foreach (Bicycle b in bikeList)
            {
                if (b.Gender.Equals(variation))
                {
                    temp.Add(b);
                }
            }

            return temp;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Bicycle selected = bikesLbx.SelectedItem as Bicycle;

            if(selected != null)
            {
                bikeList.Remove(selected);
                cartList.Add(selected);

                totalCost += selected.Price;
                priceTBlk.Text = totalCost.ToString("C");
            }
            bikesLbx.ItemsSource = bikeList;
            cartLbx.ItemsSource = cartList;
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            Bicycle selected = cartLbx.SelectedItem as Bicycle;

            if (selected != null)
            {
                cartList.Remove(selected);
                bikeList.Add(selected);

                totalCost -= selected.Price;
                priceTBlk.Text = totalCost.ToString("C");
            }
            cartLbx.ItemsSource = cartList;
            bikesLbx.ItemsSource = bikeList;
        }
    }
}
