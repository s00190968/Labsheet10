using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Bicycle
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Gender { get; set; }

        public Bicycle(string iD, string name, string gender, decimal price)
        {
            ID = iD;
            Name = name;
            Price = price;
            Gender = gender;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}e.",ID, Name, Gender, Price);
        }
    }
}
