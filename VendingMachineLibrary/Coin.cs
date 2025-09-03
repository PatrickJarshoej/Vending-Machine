using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{
    public class Coin
    {
        public static double Value {get;set;} 
        public int AmountLeft {get;set;}
        
        public Coin(double value, int amountLeft)
        {
            Value = value;
            AmountLeft = amountLeft;
        }
    }
}
