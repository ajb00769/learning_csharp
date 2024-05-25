using System;
using Animals;
using Pets;

namespace Main
{
    public class Program
    {
        static void Main()
        {
            Animal regularAnimal = new Animal("Giraffe");
            regularAnimal.SayName();

            Dog newDog = new Dog("Scooby");
            newDog.Bark();

            Cat newCat = new Cat("Floofs");
            newCat.Meow();
        }
    }
}