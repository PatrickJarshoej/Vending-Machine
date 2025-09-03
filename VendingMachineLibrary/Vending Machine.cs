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
                if (Wares[position].CheckAmount() > 0) //Checks whether we have any left
                {
                    Debug.WriteLine($"Debug, amount left: {Wares[position].CheckAmount()}");
                    return true;//If we do we return, that yes, we do have some.
                }
                else
                {
                    Console.WriteLine("Not enough stock left"); 
                    return false;
                }
        }
            catch //If nothing exists on Wares[Position] we get a KeyNotFoundException
            {
                Console.WriteLine("This product does not seem to exist in our system"); //So the say the product does not seem to exist in our system
                return false;
            }
}
        public Product? Purchase(double userBalance,int position)
        {
            if (SearchForProduct(position) == true)
            {
                if (Wares[position].CheckAmount() <= 0) //Checks if we have 0 (or less)
                {
                    Console.WriteLine("Product is out of stock"); //Tells them the product is out of stock, despite the fact they could see it was out of stock when they chose it
                    return null; 
                }
                else 
                { 
                    if (userBalance == Wares[position].Price)//If they have exactly enough, there is no need to run calculation for return
                    {
                        CheckUserBalance(userBalance);
                        return Wares[position].Dispense(); 
                    }
                    else if (userBalance < Wares[position].Price) //If they are too poor
                    {
                        Console.WriteLine("YOU have insufficient funds"); //Most people are blind, so you is in capital
                        return null;
                    }
                    else if (userBalance > Wares[position].Price) //If they have enough money to pay
                    {
                        CheckUserBalance(userBalance); //Take their balance and turns it into coins the system can use
                        if (CalculateReturn(userBalance, Wares[position]) == 0 ) //We calculate
                        {
                            return Wares[position].Dispense();
                        }
                        else
                        {
                            CalculateReturn(userBalance, Wares[0]); //Ware 0 is an adming object with a value of zero so we return the full amount of money without creating another method
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
        public void CheckUserBalance(double userBalance)
        {
            double tempBalance = userBalance; 

            double twenties = Math.Floor(tempBalance / 20); //Example, 44/20 would be 2
            tempBalance = tempBalance - 20 * twenties; //Then it take and remove 2 twenties, so 40 from the balance
            Coins["Coin 20"] += twenties; //Adds said twenties to the accessible

            double tens = Math.Floor(tempBalance / 10);
            tempBalance = tempBalance - 10 * tens;
            Coins["Coin 10"] += tens;


            double fives = Math.Floor(tempBalance / 5);
            tempBalance = tempBalance - 5 * fives;
            Coins["Coin 5"] += fives;    

            double twos = Math.Floor(tempBalance / 2);
            tempBalance = tempBalance - 2 * twos;
            Coins["Coin 2"] += twos;    

            double ones = Math.Floor(tempBalance / 1);
            tempBalance = tempBalance - 1 * twos;
            Coins["Coin 1"] += twos;    

            double halves = Math.Floor(tempBalance / 0.5);
            tempBalance = tempBalance - 0.5 * halves;
            Coins["Coin 0.5"] += halves;            

        }

        public void AddNewWare(string pName, int key, double price)
        {
            Wares.Add(key, new Ware(key, price, new Queue<Product>(), pName)); //It starts with and empty product list, meaning the stock is zero, you need to refill it
        }
        public void RemoveWare(int key)
        {
            Wares.Remove(key);
        }

        private double CalculateReturn(double userBalance, Ware p)
        {
            double tempBalance = userBalance - p.Price; //Temporary value so we can always check what they put in
            double twenties = Math.Floor(tempBalance / 20); //Same concept at CheckUserBalance()

            if (Coins["Coin 20"] >= twenties) //Checks whether or not we have enough twenties in the system to pay the user
            {
                tempBalance = tempBalance - 20 * twenties; //If we do have enough, it removes the money from the temp balance
                //Debug.WriteLine("User balance is: " + tempBalance + " after calc 20"); //This is just a check, not needed anymore
            }
            else { twenties = 0; } //Since we define 20 outside the if statement, we need to revert it to zero so we dont give them more money than they put in

            double tens = Math.Floor(tempBalance / 10);
            if (Coins["Coin 10"] >= tens)
            {
                tempBalance = tempBalance - 10 * tens;
                //Debug.WriteLine("User balance is: " + tempBalance + " after calc 10");
            }
            else { tens = 0; }

            double fives = Math.Floor(tempBalance / 5);
            if (Coins["Coin 5"] >= fives)
            {
                tempBalance = tempBalance - 5 * fives;
                //Debug.WriteLine("User balance is: " + tempBalance + " after calc 5");
            }
            else { fives = 0; }

            double twos = Math.Floor(tempBalance / 2);
            if (Coins["Coin 2"] >= twos)
            {
                tempBalance = tempBalance - 2 * twos;
                //Debug.WriteLine("User balance is: " + tempBalance + " after calc 2");
            }
            else { twos = 0; }

            double ones = Math.Floor(tempBalance / 1);
            if (Coins["Coin 1"] >= ones)
            {
                tempBalance = tempBalance - 1 * ones;
                //Debug.WriteLine("User balance is: " + tempBalance + " after calc 1");
            }
            else { ones = 0; }

            double halves = Math.Floor(tempBalance / 0.5);
            if (Coins["Coin 0.5"] >= halves)
            {
                tempBalance = tempBalance - 0.5 * halves;
                //Debug.WriteLine("User balance is: " + tempBalance + " after calc 0.5");
            }
            else 
            { 
                halves = 0;
            }

            //Debug.WriteLine(userBalance - p.Price); //This was to check whether the money returned actually matched the amount it should return
            Console.WriteLine($"returnere {twenties} tyvere og {tens} tiere og {fives} femmere og {twos} toere og {ones} enere og {halves} 50 øre ");

            Coins["Coin 20"] = Coins["Coin 20"] - twenties; //Removes the used coins from our system
            Coins["Coin 10"] = Coins["Coin 10"] - tens;     //which is why we had to set them to 0 if we don't have enough
            Coins["Coin 5"] = Coins["Coin 5"] - fives;
            Coins["Coin 2"] = Coins["Coin 2"] - twos;
            Coins["Coin 1"] = Coins["Coin 1"] - ones;
            Coins["Coin 0.5"] = Coins["Coin 0.5"] - halves;

            return tempBalance;

        }
       

        public Vending_Machine(Dictionary<int, Ware> wares,Dictionary<string, double> coins) 
        {
            Wares = wares;
            Wares.Add(0, new Ware(0, 0, new Queue<Product>(), "admin")); //Creates an admin object with a price of 0, used for returning money
            Coins = coins;
        }
        
    }
}
