namespace VendingMachineLibrary
{
    public class Ware
    {
        public int Position { get; set; }
        public double Price { get; set; }
        public Queue<Product> Products { get; set; }
        public string Name { get; set; }

        public int CheckAmount()
        {
            return Products.Count;
        }
        public void Refill(int amount) //Just adds stuff to the queue
        {
            for (int i = 0; i < amount; i++)
            {
                Products.Enqueue(new Product(Name));
            }
        }
        public Product Dispense() //Simply returns the next object in the queue. Limited to one at a time as that is how vending machines generally work
        {
            return Products.Dequeue();
        }
        public List<Product> AdminDispense(int amount) //Admins should able to dispense more than one at a time.
        {
            List<Product> products = new(); //Just a simple for loop adding objects to a list and returning the list
            for (int i = 0; i < amount; i++)
            {
                products.Add(Products.Dequeue());
            }
            return products;
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
