namespace HelloSubClass
{
    /// <summary>
    /// Example base class
    /// </summary>
    public class BaseClass
    {
        /// <summary>
        /// Example property
        /// </summary>
        public virtual string StringProperty => "Base String Property";

        /// <summary>
        /// Example method
        /// </summary>
        /// <returns>Returns string.</returns>
        public virtual string Method1()
        {
            return "Base Method1";
        }
    }
}