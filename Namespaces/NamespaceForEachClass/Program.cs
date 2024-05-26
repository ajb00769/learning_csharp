using System;
using Animals;
using Pets;
using PetHandler;

namespace Main
{
    public class Program
    {
        static void Main()
        {
            Animal regularAnimal = new Animal("Giraffe");
            regularAnimal.SayName();
            regularAnimal.MakeSound();

            Dog newDog = new Dog("Scooby");
            newDog.SayName();
            newDog.MakeSound();

            Cat newCat = new Cat("Floofs");
            newCat.SayName();
            newCat.MakeSound();

            DogHandler newDogHandler = new DogHandler("Rob", newDog);
            newDogHandler.WalkDog();
        }
    }
}