namespace HelloInterface
{
    /// <summary>
    /// Example interface
    /// </summary>
    public interface IGreet
    {
        /// <summary>
        /// Gets message by property.
        /// </summary>
        string GreetMessage { get; }

        /// <summary>
        /// Gets message.
        /// </summary>
        /// <returns>Returns message.</returns>
        string Greet();
    }
}