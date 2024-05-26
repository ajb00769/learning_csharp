using System;
using Pets;

namespace PetHandler
{
    public class DogHandler
    {
        public string? DogHandlerName;
        public Pets.Dog PetDog;

        public DogHandler(string handlerName, Pets.Dog dogObj)
        {
            this.DogHandlerName = handlerName;
            this.PetDog = dogObj;
        }

        public void WalkDog()
        {
            System.Console.WriteLine($"{DogHandlerName} is walking the dog: {PetDog.GetDogName()}");
        }
    }
}