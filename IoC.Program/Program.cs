using IoC.Program.Provider;
using IoC.Program.Repository;
using IoC.Container;

namespace Ioc.Program
{
    class Program
    {
        static void Main(string[] args)
        { 
            //Initialize the Simple Container
            ISimpleContainer container = new SimpleContainer();
            //Register IConsoleProvider as HelloWorldConsoleProvider
            container.Register<IConsoleProvider, HelloWorldConsoleProvider>();

            var HelloWorldConsole = container.Resolve<ConsoleRepository>();
            ((ConsoleRepository)HelloWorldConsole).PrintOutput();
        }
    }
}
