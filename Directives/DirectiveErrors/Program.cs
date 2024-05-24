using System;

namespace Errors
{
    public class Program
    {
        static void Main()
        {
#warning Code is deprecated.
#error Deprecated code.
#error version
            System.Console.WriteLine("Hello, world!");
        }
    }
}

/*
Not much to say about the #error directive, it just raises the CS1029
error in the pre-compile phase preventing the code from compiling.

Some use cases involve the code being deprecated. The #error version
directive is treated specially where it outputs the compiler version
and language (C#) version under the CS8304 error. 
*/