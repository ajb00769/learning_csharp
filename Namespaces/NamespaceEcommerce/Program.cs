using System;
using Customers;
using Products;
using Orders;
using System.Collections.Generic;

namespace Ecommerce
{
    static class Program
    {
        static void Main()
        {
            Customer NewCustomer = new("Harry Potter", "Door 101, House Gryffindor, Some Magic St., Potterverse");
            Product NewProductOne = new("Magic Wand", 99.99m);
            Product NewProductTwo = new("Wizard Coat", 49.99m);

            Order NewOrder = new(NewCustomer);

            Customer NewCustomerTwo = new("Hermione Granger", "Door 201, House Slytherin, Some Magic St., Potterverse");
            List<Product> NewOrderList = [NewProductOne, NewProductTwo];

            Order NewOrderTwo = new(NewCustomerTwo, NewOrderList);

            NewOrder.AddToCart(NewProductOne);
            NewOrder.CountItemsInCart();
            NewOrderTwo.CountItemsInCart();

            NewOrder.GetCartTotalPrice();
            NewOrderTwo.GetCartTotalPrice();
        }
    }
}