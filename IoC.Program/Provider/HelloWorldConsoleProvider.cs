using System;

namespace IoC.Program.Provider
{
    public class HelloWorldConsoleProvider : IConsoleProvider
    {
        public void PrintOutput()
        {
            Console.WriteLine("Hello World");
        }
    }
}
