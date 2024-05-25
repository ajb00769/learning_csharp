using System;
using System.Runtime.InteropServices;

namespace Animals
{
    public class Animal
    {
        private string? AnimalName;
        public Animal(string animalName)
        {
            this.AnimalName = animalName;
        }

        public void SayName()
        {
            System.Console.WriteLine($"My name is: {this.AnimalName}");
        }
    }
}