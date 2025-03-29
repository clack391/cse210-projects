using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    // Address class
    public class Address
    {
        private string street;
        private string city;
        private string stateOrProvince;
        private string country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            this.street = street;
            this.city = city;
            this.stateOrProvince = stateOrProvince;
            this.country = country;
        }

        // Returns true if the address is in the USA.
        public bool IsInUSA()
        {
            // Check if the country is "USA" or "UNITED STATES" (case insensitive).
            return country.Trim().ToUpper() == "USA" || country.Trim().ToUpper() == "UNITED STATES";
        }

        // Returns the full address as a string.
        public string GetAddressString()
        {
            return $"{street}\n{city}, {stateOrProvince}\n{country}";
        }
    }

    // Customer class
    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        // Returns true if the customer lives in the USA.
        public bool IsInUSA()
        {
            return address.IsInUSA();
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }
    }

    // Product class
    public class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        // Returns the total cost for this product (price * quantity).
        public double GetTotalCost()
        {
            return price * quantity;
        }

        // Returns a string with the product name and id.
        public string GetProductDetails()
        {
            return $"Product: {name} (ID: {productId})";
        }
    }

    // Order class
    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        // Adds a product to the order.
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Calculates the shipping cost based on customer's location.
        public double GetShippingCost()
        {
            // Shipping cost: $5 if the customer lives in the USA, else $35.
            return customer.IsInUSA() ? 5 : 35;
        }

        // Calculates the total cost (sum of all product costs plus shipping cost).
        public double GetTotalCost()
        {
            double total = 0;
            foreach (Product product in products)
            {
                total += product.GetTotalCost();
            }
            total += GetShippingCost();
            return total;
        }

        // Returns the packing label that lists product names and IDs.
        public string GetPackingLabel()
        {
            StringBuilder label = new StringBuilder();
            foreach (Product product in products)
            {
                label.AppendLine(product.GetProductDetails());
            }
            return label.ToString();
        }

        // Returns the shipping label with the customer's name and full address.
        public string GetShippingLabel()
        {
            return $"{customer.GetName()}\n{customer.GetAddress().GetAddressString()}";
        }
    }

    // Main program to demonstrate the classes.
    class Program
    {
        static void Main(string[] args)
        {
            // Order 1: Domestic Customer
            Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
            Customer customer1 = new Customer("Alice Smith", address1);
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "LP1001", 799.99, 1));
            order1.AddProduct(new Product("Mouse", "MS2002", 19.99, 2));

            // Order 2: International Customer
            Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Bob Johnson", address2);
            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Smartphone", "SP3003", 599.99, 1));
            order2.AddProduct(new Product("Headphones", "HP4004", 49.99, 1));
            order2.AddProduct(new Product("Charger", "CH5005", 29.99, 1));

            // Display order details for Order 1
            Console.WriteLine("Order 1 Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine("Order 1 Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Order 1 Shipping Cost: ${order1.GetShippingCost():0.00}");
            Console.WriteLine($"Order 1 Total Cost: ${order1.GetTotalCost():0.00}\n");

            // Display order details for Order 2
            Console.WriteLine("Order 2 Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine("Order 2 Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Order 2 Shipping Cost: ${order2.GetShippingCost():0.00}");
            Console.WriteLine($"Order 2 Total Cost: ${order2.GetTotalCost():0.00}");

            // Pause to view output (if running in a non-debug environment)
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
