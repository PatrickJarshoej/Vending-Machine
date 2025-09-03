using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineLibrary
{
    public class Vending_Machine
    {
        public Dictionary<int,Ware> Wares { get; set; }
        public Dictionary<string,double> Coins { get; set; } 

        public bool SearchForProduct(int position)
        {
            try
            {
                if (Wares[position].CheckAmount() >= 0)
                {
                    Console.WriteLine($"Debug, amount left: {Wares[position].CheckAmount()}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Not enough stock left");
                    return false;
                }
            }
            catch
            {
                Debug.WriteLine("Product does not exist");
                return false;
            }  
        }
        public Product? Purchase(double userBalance,int position)
        {
            CheckUserBalance(userBalance);
            //double userBalance = 23.5;
            if (SearchForProduct(position) == true)
            {
                //Product p = Products[position].;
                if (Wares[position].CheckAmount() <= 0)
                {
                    Console.WriteLine("Product is out of stock");
                    return null;
                    //Product is out of stock
                }
                else 
                { 
                    if (userBalance == Wares[position].Price)
                    {
                        return Wares[position].Dispense();
                        //Return product
                    }
                    else if (userBalance < Wares[position].Price)
                    {
                        Console.WriteLine("YOU have insufficient funds");
                        return null;
                        //insufficient funds
                    }
                    else if (userBalance > Wares[position].Price)
                    {
                        //Calculate return money
                        if (CalculateReturn(userBalance, Wares[position]) == 0 )
                        {
                            return Wares[position].Dispense();
                        }
                        else
                        {
                            //Not enough money in storage
                            Debug.WriteLine("Not enough money in storage");
                            Console.WriteLine("Not enough money in storage");
                            return null;
                        }
                    }
                }
                return null;
            }
            else
            {
                Debug.WriteLine("Product does not exist");
                return null;
            }

        }
        public void CheckUserBalance(int userBalance)
        {
            double tempBalance = userBalance;

            double twenties = Math.Floor(tempBalance / 20);
            tempBalance = tempBalance - 20 * twenties;
            Coins["Coin 20"] += twenties;
            
            double tens = Math.Floor(tempBalance / 10);
            tempBalance = tempBalance - 10 * tens;
            Coins["Coin 10"] += twenties;


            double fives = Math.Floor(tempBalance / 5);
            if (Coins["Coin 5"] >= fives)
            {
                tempBalance = tempBalance - 5 * fives;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 5");
            }
            else { fives = 0; }

            double twos = Math.Floor(tempBalance / 2);
            if (Coins["Coin 2"] >= twos)
            {
                tempBalance = tempBalance - 2 * twos;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 2");
            }
            else { twos = 0; }

            double ones = Math.Floor(tempBalance / 1);
            if (Coins["Coin 1"] >= ones)
            {
                tempBalance = tempBalance - 1 * ones;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 1");
            }
            else { ones = 0; }

            double halves = Math.Floor(tempBalance / 0.5);
            if (Coins["Coin 0.5"] >= halves)
            {
                tempBalance = tempBalance - 0.5 * halves;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 0.5");
            }
            else
            {
                halves = 0;
                //insufficient funds
            }
        }

        public List<Ware> GetAll()
        {
            List<Ware> wares = new();
            foreach (KeyValuePair<int, Ware> p in Wares)
            {
                wares.Add(p.Value);
            }
            return wares;
            
        }
        private double CalculateReturn(double userBalance, Ware p)
        {
            //Debug.WriteLine("User balance is: " + userBalance);
            double tempBalance = userBalance - p.Price;

            double twenties = Math.Floor(tempBalance / 20);

            if (Coins["Coin 20"] >= twenties)
            {
                tempBalance = tempBalance - 20 * twenties;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 20");
            }
            else { twenties = 0; }

            double tens = Math.Floor(tempBalance / 10);
            if (Coins["Coin 10"] >= tens)
            {
                tempBalance = tempBalance - 10 * tens;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 10");
            }
            else { tens = 0; }

            double fives = Math.Floor(tempBalance / 5);
            if (Coins["Coin 5"] >= fives)
            {
                tempBalance = tempBalance - 5 * fives;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 5");
            }
            else { fives = 0; }

            double twos = Math.Floor(tempBalance / 2);
            if (Coins["Coin 2"] >= twos)
            {
                tempBalance = tempBalance - 2 * twos;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 2");
            }
            else { twos = 0; }

            double ones = Math.Floor(tempBalance / 1);
            if (Coins["Coin 1"] >= ones)
            {
                tempBalance = tempBalance - 1 * ones;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 1");
            }
            else { ones = 0; }

            double halves = Math.Floor(tempBalance / 0.5);
            if (Coins["Coin 0.5"] >= halves)
            {
                tempBalance = tempBalance - 0.5 * halves;
                Debug.WriteLine("User balance is: " + tempBalance + " after calc 0.5");
            }
            else 
            { 
                halves = 0;
                //insufficient funds
            }

            Debug.WriteLine(userBalance - p.Price);
            Console.WriteLine($"returnere {twenties} tyvere og {tens} tiere og {fives} femmere og {twos} toere og {ones} enere og {halves} 50 øre ");

            Coins["Coin 20"] = Coins["Coin 20"] - twenties;
            Coins["Coin 10"] = Coins["Coin 10"] - tens;
            Coins["Coin 5"] = Coins["Coin 5"] - fives;
            Coins["Coin 2"] = Coins["Coin 2"] - twos;
            Coins["Coin 1"] = Coins["Coin 1"] - ones;
            Coins["Coin 0.5"] = Coins["Coin 0.5"] - halves;

            return tempBalance;

        }
       



        public Vending_Machine() { }
        public Vending_Machine(Dictionary<int, Ware> wares,Dictionary<string, double> coins) 
        {
            Wares = wares;
            Coins = coins;
        }
        
    }
}
