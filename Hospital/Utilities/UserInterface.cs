using System;
using Hospital.Commands.ManagePatients;
using Hospital.Objects;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.PatientObject;
using Hospital.Objects.WardObject;
using System.Collections.Generic;


namespace Hospital.Utilities
{
    /// <summary>
    /// Represents the user interface functionalities for the Hospital system.
    /// </summary>
    internal class UserInterface
    {
        /// <summary>
        /// Displays an interactive menu with items implementing IHasIntroduceString interface.
        /// </summary>
        /// <typeparam name="T">Type of items that implement IHasIntroduceString.</typeparam>
        /// <param name="items">List of items to display.</param>
        /// <returns>Selected item of type T.</returns>
        public static T ShowInteractiveMenu<T>(List<T> items) where T : IHasIntroduceString
        {
            int selectedLineIndex = 0;
            ConsoleKey pressedKey;

            do
            {
                UpdateInteractiveMenu(items, selectedLineIndex);
                pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.DownArrow && selectedLineIndex + 1 < items.Count)
                    selectedLineIndex++;

                else if (pressedKey == ConsoleKey.UpArrow && selectedLineIndex - 1 >= 0)
                    selectedLineIndex--;

            } while (pressedKey != ConsoleKey.Enter);

            return items[selectedLineIndex];
        }

        /// <summary>
        /// Displays an interactive menu with string options.
        /// </summary>
        /// <param name="options">List of string options to display.</param>
        /// <returns>Selected option as a string.</returns>
        public static string ShowInteractiveMenu(List<string> options)
        {
            int selectedLineIndex = 0;
            ConsoleKey pressedKey;

            do
            {
                UpdateInteractiveMenu(options, selectedLineIndex);
                pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.DownArrow && selectedLineIndex + 1 < options.Count)
                    selectedLineIndex++;

                else if (pressedKey == ConsoleKey.UpArrow && selectedLineIndex - 1 >= 0)
                    selectedLineIndex--;

            } while (pressedKey != ConsoleKey.Enter);

            return options[selectedLineIndex];
        }

        /// <summary>
        /// Displays an interactive menu with health status options.
        /// </summary>
        /// <returns>Selected health status as a Health enum value.</returns>
        public static Health ShowInteractiveMenu()
        {
            var options = Enum.GetNames(typeof(Health)).ToList();
            int selectedLineIndex = 0;
            ConsoleKey pressedKey;

            do
            {
                UpdateInteractiveMenu(options, selectedLineIndex);
                pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.DownArrow && selectedLineIndex + 1 < options.Count)
                    selectedLineIndex++;

                else if (pressedKey == ConsoleKey.UpArrow && selectedLineIndex - 1 >= 0)
                    selectedLineIndex--;

            } while (pressedKey != ConsoleKey.Enter);

            return (Health)Enum.Parse(typeof(Health), options[selectedLineIndex]);
        }

        /// <summary>
        /// Displays a message to the user with an option to proceed.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public static void ShowMessage(string message)
        {
            ConsoleKey pressedKey;

            Console.Clear();
            Console.WriteLine(message);
            DrawSelectedMenu("ok!");
            do
            {
                pressedKey = Console.ReadKey().Key;

            } while (pressedKey != ConsoleKey.Enter);
        }

        /// <summary>
        /// Refreshes the interactive menu display with items implementing IHasIntroduceString.
        /// </summary>
        /// <typeparam name="T">Type of items that implement IHasIntroduceString.</typeparam>
        /// <param name="items">List of items to display.</param>
        /// <param name="selectedIndex">Index of the currently selected item.</param>
        private static void UpdateInteractiveMenu<T>(List<T> items, int selectedIndex) where T : IHasIntroduceString
        {
            Console.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                bool isSelected = i == selectedIndex;
                if (isSelected)
                    DrawSelectedMenu(items[i].IntroduceString);
                else
                    Console.WriteLine(items[i].IntroduceString);
            }
        }

        /// <summary>
        /// Refreshes the interactive menu display with string options.
        /// </summary>
        /// <param name="options">List of string options to display.</param>
        /// <param name="selectedIndex">Index of the currently selected option.</param>
        private static void UpdateInteractiveMenu(List<string> options, int selectedIndex)
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                bool isSelected = i == selectedIndex;
                if (isSelected)
                    DrawSelectedMenu(options[i]);
                else
                    Console.WriteLine($"  {options[i]}");
            }
        }

        /// <summary>
        /// Draws the currently selected menu option with specific formatting.
        /// </summary>
        /// <param name="option">Option string to display as selected.</param>
        private static void DrawSelectedMenu(string option)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"> {option}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}