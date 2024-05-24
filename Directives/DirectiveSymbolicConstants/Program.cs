using System;

namespace SymbolicConstants
{
    public class Program
    {
        public const UInt16 MaxGoldValue = 65535;
        public const UInt16 MaxSilverValue = 99;
        public const UInt16 MaxCopperValue = 99;
        static void Main()
        {
            System.Console.WriteLine($"MAX_GOLD  : {MaxGoldValue}");
            System.Console.WriteLine($"MAX_SILVER: {MaxSilverValue}");
            System.Console.Write($"MAX_COPPER: {MaxCopperValue}");
        }
    }
}

/*
Symbolic Constants are pre-compiler assigned variable declarations that
cannot be changed. A great example for this in C will look like:

#define HOUR 3600

The constant value for HOUR can then be used in code or in some other
directives like #if #elif #else #ifdef #ifndef etc.

In the case of C# these directive symbolic constants are not created
and assigned under Directives since variable assignement is not supported
for directives but as an alternative these are symbolic constants can be
declared with the 'const' keyword and should be at the class-level scope.

C#'s way of handling symbolic constants are also safer than C's directive
symbolic constants because in C# the type is checked. In C the pre-compiler
does not check types.

Directive Symbolic Constants are typically used to assign limits (like the
limits.h header file in C), mathematical constants, and app configurations.
*/