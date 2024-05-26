using System;
using System.Runtime.InteropServices;

namespace Animals
{
    public class Animal
    {
        public string? AnimalName;

        public Animal(string animalName)
        {
            this.AnimalName = animalName;
        }

        public void SayName()
        {
            System.Console.WriteLine($"My name is: {this.AnimalName}");
        }

        public virtual void MakeSound()
        {
            System.Console.WriteLine($"{AnimalName}: this is a default sound. I don't know what sound I make since I am just a general animal.");
        }
    }
}