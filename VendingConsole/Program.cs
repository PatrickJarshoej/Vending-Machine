using System.Diagnostics;
using System.Drawing;
using VendingMachineLibrary;
namespace VendingConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string,double> coins = new() 
            {
                { "Coin 0.5", 124 },
                { "Coin 1", 892 },
                { "Coin 2", 22 },
                { "Coin 5", 224 },
                { "Coin 10", 256 },
                { "Coin 20", 55 }
            };


            Dictionary<int, Ware> wares = new()
            {
                {11, new Ware(11, 15.5, new Queue<Product>(), "Fish")},     //Position, Price, Queue of objects, Name
                {12, new Ware(12, 30, new Queue<Product>(), "Chips")},      //Position, Price, Queue of objects, Name
                {21, new Ware(21, 10, new Queue<Product>(), "White Monster")},     //Position, Price, Queue of objects, Name
                {22, new Ware(22, 20, new Queue<Product>(), "Rio Punch Monster")}     //Position, Price, Queue of objects, Name
            };

            wares[11].Refill(13);
            wares[12].Refill(26);
            wares[21].Refill(5);
            wares[22].Refill(17);

            Vending_Machine vendingMachine = new(wares,coins);
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose");
                Console.WriteLine("1: Would you like to buy");
                Console.WriteLine("2: Admin Shit");
                Console.WriteLine("3: Would you like die?");
                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("What would you like to buy, insert the number in front, not the name");
                        foreach (KeyValuePair<int,Ware> w in vendingMachine.Wares) //Writes out all wares
                        {
                            Console.WriteLine($"{w.Key}:    {w.Value.Name}     {w.Value.Price} kr");
                        } //Shows the key, name and price

                        choice = Int32.Parse(Console.ReadLine()); //The choice is the key
                        vendingMachine.SearchForProduct(choice);

                        Console.WriteLine("Insert money");
                        int money = Int32.Parse(Console.ReadLine());

                        Console.WriteLine(vendingMachine.Purchase(money, choice).Name + " Has been dispensed");
                        break;
                    case 2:
                        Console.WriteLine("What would you like to do?");
                        Console.WriteLine("1: Restock");
                        Console.WriteLine("2: Dispense");
                        Console.WriteLine("3: Fill up coins");
                        Console.WriteLine("4: Change Price");
                        Console.WriteLine("5: Add new Ware");
                        Console.WriteLine("6: Remove old Ware");
                        choice = Int32.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("What would you like to restock?");
                                foreach (KeyValuePair<int, Ware> w in vendingMachine.Wares)
                                {
                                    Console.WriteLine($"{w.Key}:    {w.Value.Name}     {w.Value.Products.Count} left");
                                }
                                choice = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("How many?");
                                int refillAmount = Int32.Parse(Console.ReadLine());
                                vendingMachine.Wares[choice].Refill(refillAmount);

                                break;
                            case 2:
                                Console.WriteLine("What would you like to Dispense?");

                                foreach (KeyValuePair<int, Ware> w in vendingMachine.Wares)
                                {
                                    Console.WriteLine($"{w.Key}:    {w.Value.Name}     {w.Value.Products.Count} left");
                                }
                                choice = Int32.Parse(Console.ReadLine());
                                
                                Console.WriteLine("How many?");
                                int dispenseAmount = Int32.Parse(Console.ReadLine());

                                vendingMachine.Wares[choice].AdminDispense(dispenseAmount);
                                Console.WriteLine(vendingMachine.Wares[choice].Products.Count);
                                break;
                            case 3:
                                Console.WriteLine("What coin type would you like to fill up?");

                                foreach (KeyValuePair<string, double> c in vendingMachine.Coins)
                                {
                                    Console.WriteLine($"{c.Key}:    {c.Value}");
                                }

                                string choice2 = Console.ReadLine();
                                Console.WriteLine("How many?");

                                double coinAmount = Int32.Parse(Console.ReadLine());
                                vendingMachine.Coins[choice2] = vendingMachine.Coins[choice2] + coinAmount;

                                break;
                            case 4:
                                Console.WriteLine("What price would you like to change?");
                                j = 0;
                                foreach (KeyValuePair<int, Ware> w in vendingMachine.Wares)
                                {
                                    j++;
                                    Console.WriteLine($"{w.Key}:    {w.Value.Name}     {w.Value.Products.Count} left");
                                }
                                choice = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("What would you like to change it to?");
                                int newPrice = Int32.Parse(Console.ReadLine());
                                vendingMachine.Wares[choice].Price = newPrice;

                                break;
                            case 5:
                                Console.WriteLine("What is the name of this Ware?");
                                string pName = Console.ReadLine();
                                Console.WriteLine("What is the key of this Ware?");
                                int pKey = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("What is the price of this Ware?");
                                double pPrice = double.Parse(Console.ReadLine());

                                vendingMachine.AddNewWare(pName, pKey, pPrice);

                                break;

                            case 6:
                                Console.WriteLine("What ware would you like to remove?");
                                int key = Int32.Parse(Console.ReadLine());
                                vendingMachine.RemoveWare(key);
                                break;
                        }
                        break;
                    case 3:

                        Console.WriteLine("How?");
                        Console.WriteLine("1: safe?");
                        Console.WriteLine("2: Dumb?");
                        choice = Int32.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                running = false;
                                break;
                            case 2:
                                int a = 0;
                                Console.WriteLine(a / a);
                                break;
                        }
                        break;
                }
            }
        }
    }
}
