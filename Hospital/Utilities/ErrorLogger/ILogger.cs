namespace Hospital.Utilities.ErrorLogger
{
    internal interface ILogger
    {
        void WriteLog(string ex);
        void HandleError(string message, Exception ex);
        void HandleError(Exception ex);
    }
}