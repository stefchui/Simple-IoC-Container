using IoC.Program.Provider;

namespace IoC.Program.Repository
{
    public class ConsoleRepository
    {
        private readonly IConsoleProvider _consoleProvider;

        public ConsoleRepository(IConsoleProvider consoleProvider)
        {
            this._consoleProvider = consoleProvider;
        }

        public void PrintOutput()
        {
            this._consoleProvider.PrintOutput();
        }
    }
}
