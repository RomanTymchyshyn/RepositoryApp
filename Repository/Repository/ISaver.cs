namespace Repository
{
    /// <summary>
    /// Interface for objects, that can save events to the different storages
    /// </summary>
    public interface ISaver
    {
        /// <summary>
        /// Saves events.
        /// </summary>
        /// <param name="overwrite">Determines whether this event must be overwrited if there already exists such event in the repository.</param>
        /// <param name="events">Events that you want to save.</param>
        void SaveEvents(bool overwrite, params Event[] events);
    }
}
