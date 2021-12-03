namespace Logger
{
    /// <summary>
    /// Interface for <see cref="Log"/>.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Log exception message.
        /// </summary>
        /// <param name="message">Message.</param>
        void LogException(string message);
    }
}