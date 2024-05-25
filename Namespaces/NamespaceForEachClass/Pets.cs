using System;

namespace Pets
{
    public class Dog
    {
        private string? DogName;

        public Dog(string dogName)
        {
            this.DogName = dogName;
        }

        public void Bark()
        {
            System.Console.WriteLine($"{DogName}: Bark bark bark!");
        }
    }

    public class Cat
    {
        private string? CatName;

        public Cat(string catName)
        {
            this.CatName = catName;
        }

        public void Meow()
        {
            System.Console.WriteLine($"{CatName}: Meow meow meow...");
        }
    }
}