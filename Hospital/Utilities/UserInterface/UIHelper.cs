using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Utilities.UI
{
    internal class UIHelper
    {
        /// <summary>
        /// Handles and displays an error message.
        /// In the future, the exception message will be logged to a text file.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        /// <param name="ex">The exception associated with the error.</param>
        public static void HandleError(string message, Exception ex)
        {
            UI.ShowMessage(message);
            //Exception message will be logged to the txt file
        }
    }
}