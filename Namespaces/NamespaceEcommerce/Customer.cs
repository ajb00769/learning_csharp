using System;

namespace Customers
{
    public class Customer
    {
        public string CustomerName;
        public string CustomerAddr;

        public Customer(string custName, string custAddr)
        {
            CustomerName = custName;
            CustomerAddr = custAddr;
            System.Console.WriteLine($"[LOG] Customer account '{CustomerName}' successfully created.");
        }
    }
}