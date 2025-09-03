using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{
    public class Product : Ware
    {
        public string Name { get; set; }
        public Product(string name)
        {
            Name = name;
        }
    }
}
