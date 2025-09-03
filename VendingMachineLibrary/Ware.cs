namespace VendingMachineLibrary
{
    public class Ware
    {
        public int Position { get; set; }
        //public int AmountLeft { get; set; }
        public double Price { get; set; }
        Queue<Product> Products { get; set; }
        public string Name { get; set; }

        public int CheckAmount()
        {
            return Products.Count;
        }
        public void Refill(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Products.Enqueue(new Product(Name));
            }
        }
        public Product Dispense()
        {
            return Products.Dequeue();
        }
        public Ware(int position, double price,Queue<Product> products, string name)
        {
            Position = position;
            Price = price;
            Products = products;
            Name = name;
        }
        public Ware() { }


    }
}
