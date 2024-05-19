#undef DEBUG 
#pragma warning disable CS0168, CS0219

using System;
using System.Diagnostics;

namespace Directive
{
    public static class Program
    {
        public static void Main()
        {
            const int x = 0;
            int y = 1;
            int z = 2;
            System.Console.WriteLine($"The value of x is {x}");
            System.Console.WriteLine($"The value of y is {y}");
            System.Console.WriteLine($"The value of z is {z}");
            System.Console.WriteLine("OK");
#if DEBUG
            y = 10;
            System.Console.WriteLine("Debug mode is enabled.");
            System.Console.WriteLine($"This section of code will only be compiled or appear if the directive conditional is true.so attempting to print the modified value of z which is 20 won't work, z here is: {z}");
#else
            z = 20;
            System.Console.WriteLine("Debug mode is disabled.");
            System.Console.WriteLine($"This section of code will only be compiled or appear if the directive conditional is true. In the conditional directive above y was changed to 10 but since the conditional is false the value of y remains unchanged: y is {y}");
#endif
        }
    }
}
// #pragma warning restore CS0168, CS0219

/*
Directives are read by the precompiler before compiling the actual code and logic.

Except for #if #else #elif directives, directives are not affected by code logic.
In the context of C# compilation there is no separate preprocessor or precompiler,
everything is handled by one compiler. The flow happens:

 - Compiler SCANS FOR DIRECTIVES to use them as instructions before compiling, it
   will modify the source code to account for the instructions in the directives
   and will OUTPUT PREOPROCESSED SOURCE CODE
 - The LEXICAL ANALYZER scans the preprocessed code and PARTITIONS each word
   separated by spaces INTO INDIVIDUAL LEXICAL TOKENS
 - Lexical tokens are then used to CHECK FOR SYNTAX ERRORS like MISSING SEMICOLONS,
   UNMATCHED PARENTHESES, MISSPELLED KEYWORDS, etc.
 - SYNTAX ANALYSIS then takes place where it takes the sequence of lexical tokens
   and arranges them into a hierarchal structure by TAKING the KEYWORDS from the
   source code and creating a tree-like structure called the PARSE TREE.
 - The generated parse trees' structure is then checked if the GENERATED STRUCTURE
   is VALID by CHECKING it AGAINST STORED VALID TREE STRUCTURES.
 - SEMANTIC ANALYSIS then takes place checking the parse tree for semantic errors
   such as undeclared variables, incompatible data types, etc.
   * NOTE: LINTERS user SEMANTIC ANALYSIS so you can catch these errors before even
   attempting to run your code.
 - CIL code is then generated after all validations and checks have been performed
   or if no compile-time errors are caught. This signified the end of compile-time.
 - CODE OPTIMIZATION is then performed by the compiler on the intermediate code or
   CIL code to improve code efficiency or make the size smaller.
 - C# CIL interprets the bytecode and runs it in the virtual machine, this is where
   runtime begins.

In the case of #if #else #elif directives these sections of code are checked by the
preprocessor and executed before actual code compilation.
*/