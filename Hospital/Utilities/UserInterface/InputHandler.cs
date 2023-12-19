using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Utilities.UserInterface
{
    public class InputHandler : IInputHandler
    {
        private readonly IConsoleService _consoleService;

        public InputHandler(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }

        public string GetInput(string prompt)
        {
            _consoleService.Clear();
            _consoleService.WriteLine(prompt);
            return _consoleService.ReadLine().ToString();
        }

        public int GetIntInput(string prompt)
        {
            string? input;
            int result;

            do
            {
                _consoleService.Clear();
                _consoleService.WriteLine(prompt);
                input = _consoleService.ReadLine();
            }
            while (!int.TryParse(input, out result));

            return result;
        }

        public DateTime GetDateTimeInput(string prompt)
        {
            string? input;
            DateTime result;

            do
            {
                _consoleService.Clear();
                _consoleService.WriteLine(prompt);
                input = _consoleService.ReadLine();
            }
            while (!DateTime.TryParse(input, out result));

            return result;
        }
    }
}