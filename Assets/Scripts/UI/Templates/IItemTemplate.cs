namespace MarvelUniverse.UI.Templates
{
    /// <summary>
    /// Interface for an item template.
    /// </summary>
    /// <typeparam name="T">The type of item to display.</typeparam>
    public interface IItemTemplate<T>
    {
        /// <summary>
        /// Hook up item to template.
        /// </summary>
        /// <param name="item">The item to display.</param>
        void Hookup(T item);
    }
}