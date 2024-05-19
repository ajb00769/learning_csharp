#define DEBUG 
#pragma warning disable CS0168, CS0219

using System;
using System.Diagnostics;

namespace Directive
{
    public static class Program
    {
        public static void Main()
        {
            const string unusedString = "This variable is not used";
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
            System.Console.WriteLine($"This section of code will only be compiled or appear if the directive conditional is true/enabled debug mode. So attempting to print the modified value of z in the false conditional which is 20 won't work, z here is: {z}. The value of y is changed to 10 as reassigned in this conditional directive: y is {y}");
#else
            z = 20;
            System.Console.WriteLine("Debug mode is disabled.");
            System.Console.WriteLine($"This section of code will only be compiled or appear if the directive conditional is false/disabled debug mode. In the conditional directive above y was changed to 10 but since the conditional is false the value of y remains unchanged: y is {y}. The value of z is changed to 20 as reassigned in this conditional directive: z is {z}");
#endif
            // #pragma warning restore CS0168, CS0219
            const string anotherUnusedString = "This second variable is also unused";
        }
    }
}

/*
Directives are read by the precompiler before compiling the actual code and logic.

Directives are not affected by code logic but instead dictates how compilation
should be performed by the compiler such as only compiling certain sections of
code based on a conditional directive or if warning and error messages should be
displayed during runtime for a section of code.

In the context of C# compilation there is no separate preprocessor or precompiler,
everything is handled by one compiler. The flow happens as follows:

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
   or if no compile-time errors are caught. This signified the eND OF COMPILE-TIME.
 - CODE OPTIMIZATION is then performed by the compiler on the intermediate code or
   CIL code to improve code efficiency or make the size smaller.
 - C# CIL interprets the bytecode and runs it in the virtual machine, this is where
   RUNTIME BEGINS and where runtime errors can happen such as uncaught exceptions
   from inputs.

In the case of #if #else #elif directives these sections of code are checked by the
preprocessor and executed before actual code compilation. Hence only the section of
code inside of the conditional directive the satisfies the condition will be
compiled.

Notice that the commented out code for the pragma directive to restore the warning
is kept for illustration purposes. Pragma directives follow the order of execution
during compilation in the context of applying certain settings only within the
scope spanned across by the directive in this case the activatin and deactivation
of warning messages for certain warning types. You can test this by uncommenting
the code and only anotherUnusedString will get the warning message and unusedString
will be exempt from the warning message.
*/