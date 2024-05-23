#define TEST_MODE
#undef PROD_MODE

using System;

namespace ConditionalCompilation
{
    static class Program
    {
        static void Main()
        {
            string initMessage;
#if TEST_MODE
            initMessage = "Program running in test mode.";
#elif PROD_MODE
            initMessage = "Program running in production.";
#else
            initMessage = "Invalid program mode.";
#endif
            System.Console.WriteLine(initMessage);
        }
    }
}