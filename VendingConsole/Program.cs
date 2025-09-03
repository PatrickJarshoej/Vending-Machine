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
                //vendingMachine.Purchase(52,23);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("What would you like to buy");
                        int i = 0;
                        foreach (KeyValuePair<int,Ware> w in vendingMachine.Wares)
                        {
                            i++;
                            Console.WriteLine($"{w.Key}:    {w.Value.Name}     {w.Value.Price} kr");
                        }
                        choice = Int32.Parse(Console.ReadLine());
                        vendingMachine.SearchForProduct(choice);

                        Console.WriteLine("Insert money");
                        int money = Int32.Parse(Console.ReadLine());

                        vendingMachine.Purchase(money, choice);

                        break;
                    case 2:
                        Console.WriteLine("What would you like to do?");
                        Console.WriteLine("1: Restock");
                        Console.WriteLine("2: Dispense");
                        Console.WriteLine("3: Fill up coins");
                        Console.WriteLine("4: Change Price");
                        choice = Int32.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("What would you like to restock?");
                                int j = 0;
                                foreach (KeyValuePair<int, Ware> w in vendingMachine.Wares)
                                {
                                    j++;
                                    Console.WriteLine($"{w.Key}:    {w.Value.Name}     {w.Value.Products.Count} left");
                                }
                                choice = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("How many?");
                                int refillAmount = Int32.Parse(Console.ReadLine());
                                vendingMachine.Wares[choice].Refill(refillAmount);

                                break;
                            case 2:
                                Console.WriteLine("What would you like to Dispense?");
                                j = 0;
                                foreach (KeyValuePair<int, Ware> w in vendingMachine.Wares)
                                {
                                    j++;
                                    Console.WriteLine($"{w.Key}:    {w.Value.Name}     {w.Value.Products.Count} left");
                                }
                                choice = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("How many?");
                                int dispenseAmount = Int32.Parse(Console.ReadLine());
                                vendingMachine.Wares[choice].AdminDispense(dispenseAmount);
                                break;
                            case 3:
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
