using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Utilities.UserInterface
{
    internal class InputHandler : IInputHandler
    {
        public InputHandler() { }

        public string GetInput(string prompt)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            return Console.ReadLine().ToString();
        }

        public int GetIntInput(string prompt)
        {
            string? input;
            int result;

            do
            {
                Console.Clear();
                Console.WriteLine(prompt);
                input = Console.ReadLine();
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
                Console.Clear();
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            }
            while (!DateTime.TryParse(input, out result));

            return result;
        }
    }
}