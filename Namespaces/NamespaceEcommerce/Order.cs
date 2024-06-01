using System;
using Products;
using Customers;
using System.Collections.Generic;

namespace Orders
{
    public class Order
    {
        readonly Customers.Customer Customer;
        readonly List<Products.Product> ProductsOrdered;

        public Order(Customers.Customer customer)
        {
            Customer = customer;
            ProductsOrdered = [];
            System.Console.WriteLine($"[LOG] Cart successfully initialzed for '{Customer.CustomerName}'. {ProductsOrdered.Count} items added so far.");
        }

        // interesting to note that since classes are passed by reference, if
        // we have already addded the product ordered here and change the product
        // object that was used as input, the product ordered will also reflect
        // the change made to the input.

        public Order(Customers.Customer customer, List<Products.Product> productList)
        {
            Customer = customer;
            ProductsOrdered = productList;
            System.Console.WriteLine($"[LOG] Cart successfully initialzed for '{Customer.CustomerName}'. Product(s) {string.Join(", ", ProductsOrdered.Select(obj => obj.ProductName))} were successfully added upon initialization.");
        }

        public bool AddToCart(Products.Product product)
        {
            this.ProductsOrdered.Add(product);
            System.Console.WriteLine($"[LOG] Product {product.ProductName} added successfully to cart for '{this.Customer.CustomerName}'!");
            return true;
        }

        public void CountItemsInCart()
        {
            System.Console.WriteLine($"[LOG] There are {this.ProductsOrdered.Count} items in {this.Customer.CustomerName.ToUpper()}'s cart.");
        }

        public void GetCartTotalPrice()
        {
            List<decimal> cartAmounts = [];
            foreach (var item in ProductsOrdered)
            {
                cartAmounts.Add(item.ProductPrice);
            }
            System.Console.WriteLine($"[LOG] '{this.Customer.CustomerName}' has a cart total amount of: {cartAmounts.Sum()}");
        }
    }
}

/*
One of the more interesting things I learned here is Lists vs Arrays in C#.

I initially tried to implement GetCartTotalPrice using an array but adding
a new element into the array is quite a bit of a hassle to write since you
need multiple lines of code to do so, you will either need an index tracker
variable or create a new array only containing the current iterable element 
and merging the global array with the current iterable's single-elemet array.

Did a bit of research and learned that I was using the wrong tool for the
wrong job. Arrays are best used when the array size is known or static since
Arrays in C# are immutable data structures. They are probably best used to
hold constants.

Lists are generally better for dynamic collections because of its resizable
nature, despite the increased performance overhead since a List is a wraps
around an Array, it's generally easier to read, write, and lessens the
likelihood of errors from happening due to human error in self-implementation.
*/