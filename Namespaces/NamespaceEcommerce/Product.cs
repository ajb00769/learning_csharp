using System;

namespace Products
{
    public class Product
    {
        public string ProductName;
        public decimal ProductPrice;
        // interesting to note that if you don't specify variable declarations within
        // the class as public it defaults to private or maybe protected, either way you
        // get an access issue

        public Product(string productName, decimal productPrice)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            System.Console.WriteLine($"[LOG] Product '{ProductName}' successfully created.");
        }
    }
}