using Hospital.PeopleCategories;
using Hospital.Utilities.ErrorLogger;

namespace Hospital.Utilities.UserInterface
{
    /// <summary>
    /// Provides utility methods to facilitate user interactions and error handling.
    /// </summary>
    internal static class UiHelper
    {
        /// <summary>
        /// Displays an error message to the user and logs the associated exception.
        /// </summary>
        /// <param name="message">The error message to be displayed to the user.</param>
        /// <param name="ex">The exception associated with the error, which will be logged for further reference.</param>
        public static void HandleError(string message, Exception ex)
        {
            Ui.ShowMessage(message);
            Logger.WriteLog(ex.ToString());
        }

        /// <summary>
        /// Logs an exception without displaying any message to the user.
        /// </summary>
        /// <param name="ex">The exception to be logged.</param>
        public static void HandleError(Exception ex)
        {
            Logger.WriteLog(ex.ToString());
        }

        /// <summary>
        /// Allows the user to select an object of type T from a provided list. 
        /// Displays a provided selection prompt string to the user prior to presenting the selection options.
        /// </summary>
        /// <typeparam name="T">Type of the object the user selects. This type must implement IHasIntroduceString.</typeparam>
        /// <param name="list">The list of objects from which the user will make a selection.</param>
        /// <param name="selectString">A message or prompt to be displayed to the user prior to presenting the selection options.</param>
        /// <returns>Returns the object of type T that the user selects.</returns>
        public static T SelectObject<T>(List<T> list, string selectString) where T : IHasIntroduceString
        {
            Ui.ShowMessage(selectString);
            var obj = Ui.ShowInteractiveMenu(list);
            return obj;
        }
    }
}
