using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DirectiveRegions
{
    class Program
    {
        #region ConstantDeclarations
        public const bool AppStatusOK = true;
        public const bool AppStatusNotOK = false;
        public const string DefaultErrorMessage = "An error happened bro.";
        #endregion

        static void Main()
        {
            #region InitialStates
            bool SystemStatus = AppStatusOK;
            string StatusMessage = "OK";
            #endregion

            #region StateCheckAndAssign
            if (1 > 0)
            {
                SystemStatus = AppStatusNotOK;
            }

            if (!SystemStatus)
            {
                StatusMessage = "NOT OK";
            }
            #endregion

            #region Execution
            try
            {
                System.Console.WriteLine($"System Status: {StatusMessage}");
                throw new Exception("Bruh");
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"{DefaultErrorMessage} More details:\n{e}");
            }
            #endregion
        }
    }
}

/*
Region directives are mostly just for code readability to allow the
developer to label and group together sections within code blocks.
*/