using System;
using Animals;

namespace Pets
{
    // specify correct base class path
    public class Dog : Animals.Animal
    {
        // inherit constructor
        public Dog(string animalName) : base(animalName)
        { }

        public string GetDogName()
        {
            return this.AnimalName ?? "NoName";
        }

        public override void MakeSound()
        {
            System.Console.WriteLine($"{this.AnimalName}: Bark bark bark!");
        }
    }

    public class Cat : Animals.Animal
    {
        public Cat(string animalName) : base(animalName)
        { }

        public override void MakeSound()
        {
            System.Console.WriteLine($"{this.AnimalName}: Meow!");
        }
    }
}