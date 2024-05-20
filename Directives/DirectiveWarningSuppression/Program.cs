using System;

namespace WarningSuppression
{
    static class Program
    {
        static void Main()
        {
            int[] nums = { 1, 2, 3, 4 };
#pragma warning disable CS0251
            System.Console.WriteLine(nums[-1]);
#pragma warning restore CS0251
            /*
                Although the warning will be suppressed allowing the code to run 
                it will still return an unhandled exception for the suppressed
                error.

                I guess a real-word use case for this is custom Exception handling
                so that the developer can create custom messages for the suppressed
                error so that troubleshooting can be easier for support engineers.

                Though warning suppression should be done with caution because it runs
                the risk of obscuring the root cause of the issue which is heavily
                detailed in the built in warnings with proper tracebacks.
            */
        }
    }
}