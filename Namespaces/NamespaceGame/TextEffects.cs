using System;
using System.Threading;

namespace TextEffects
{
    public class TypeWriter
    {
        public TypeWriter() { }

        public void TypeWriteText(string textInput)
        {
            char[] CharArray = textInput.ToCharArray();

            foreach (char character in CharArray)
            {
                System.Console.Write(character);
                Thread.Sleep(10);
            }
            System.Console.WriteLine("\n");
        }
    }
}