using System;
using System.Collections.Generic;

namespace Repository
{
    /// <summary>
    /// Class that represents the repository and allow you to work with Events (Events - objects of the class <c>Event</c>).
    /// <para>You can Add event to repo and save in way you want</para>
    /// <para><seealso cref="Repository.Event"/></para>
    /// </summary>
    public class Repo
    {
        #region Fields
        private Dictionary<int, Event> _events = new Dictionary<int, Event>();

        private Dictionary<string, ISaver> _saversPool = new Dictionary<string, ISaver>();
        #endregion

        #region CTORS
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="opts">
        ///     Array of KeyValuePairs where key - name of the saving method, value - saver, that can save value in the way that you want.
        ///     <see cref="Repository.ISaver"/>
        /// </param>
        public Repo(params KeyValuePair<string, ISaver>[] opts)
        {
            this.ConfigWithNewTools(opts);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Private method which only saves event in choosed way without adding it locally.
        /// </summary>
        /// <param name="overwrite">Determines whether this event must be overwrited if there already exists such event in the repository.</param>
        /// <param name="e">Event that you want to save.</param>
        /// <param name="opts">Options of saving. Determines ways in which event must be saved.</param>
        /// <exception cref="System.ArgumentNullException">Throw when <c>opts</c> is <c>null</c></exception>
        private void SaveWithoutAdding(bool overwrite, Event e, params string[] opts)
        {
            if (opts == null) throw new ArgumentNullException("opts", "Options of saving is NULL");
            foreach (string option in opts)
            {
                ISaver saver;
                if (!_saversPool.TryGetValue(option.ToLower(), out saver))
                    throw new Exception("You are trying to save Event in unknown way");
                saver.SaveEvents(overwrite, e);
            }
        }
        #endregion

        /// <summary>
        /// Allows you to add functionality to repo in runtime.
        /// Adds new way of saving events to repository.
        /// </summary>
        /// <param name="opts">
        ///     Array of KeyValuePairs where key - <c>string</c>, which is name of the saving method,
        ///     value - <c>ISaver</c>saver, that can save value in the way that you want.
        ///     <see cref="Repository.ISaver"/>
        /// </param>
        /// <exception cref="System.ArgumentNullException">Throw when <c>opts</c> is <c>null</c></exception>
        public void ConfigWithNewTools(params KeyValuePair<string, ISaver>[] opts)
        {
            if (opts == null) throw new ArgumentNullException("opts", "Tool that you want to configurate repository with is NULL");
            foreach (KeyValuePair<string, ISaver> pair in opts)
            {
                this.ConfigWithNewTool(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Allows you to add functionality to repo in runtime.
        /// Adds new way of saving events to repository.
        /// </summary>
        /// <param name="formatName">
        ///     Name of method of saving.
        /// </param>
        /// <param name="saver">
        ///     <c>ISaver</c>saver, that can save value in the way that you want.
        /// </param>
        /// <exception cref="System.ArgumentNullException">Throw when <c>opts</c> or <c>saver</c> is <c>null</c></exception>
        /// <exception cref="System.ArgumentException">Throw when <c>formatName</c> is empty</exception>
        public void ConfigWithNewTool(string formatName, ISaver saver)
        {
            if (formatName == null) throw new ArgumentNullException("formatName", "Format Name is NULL");
            if (saver == null) throw new ArgumentNullException("Saver", "Saver is NULL");
            if (formatName == "") throw new ArgumentException("Bad name of format of saving");
            if (!_saversPool.ContainsKey(formatName.ToLower()))
                _saversPool.Add(formatName.ToLower(), saver);
        }

        /// <summary>
        /// Adds event to repository locally without saving.
        /// </summary>
        /// <param name="overwrite">
        ///     Determines whether this event must be overwrited if there already exists such event in the repository.
        /// </param>
        /// <param name="events">
        ///     Array of events that you want to save.
        /// </param>
        /// <exception cref="System.ArgumentNullException">Throw when <c>events</c> is <c>null</c></exception>
        public void AddEvents(bool overwrite, params Event[] events)
        {
            if (events == null) throw new ArgumentNullException("events", "Events that you try to add is NULL");
            foreach (Event e in events)
            {
                if (_events.ContainsKey(e.ID))
                {
                    if (overwrite)
                    {
                        _events[e.ID] = e;
                    }
                }
                else
                {
                    _events.Add(e.ID, e);
                }
            }
        }

        /// <summary>
        ///     Adds event to repository and saves it in the way descibed by opts parameter
        /// </summary>
        /// <param name="overwrite">
        ///     Determines whether this event must be overwrited if there already exists such event in the repository.
        /// </param>
        /// <param name="e">
        ///     Event that you want to save.
        /// </param>
        /// <param name="opts">
        ///     Array of options, which describe ways to save event.
        /// </param>
        /// <exception cref="System.ArgumentNullException">Throw when <c>opts</c> is <c>null</c></exception>
        public void SaveEvent(bool overwrite, Event e, params string[] opts)
        {
            if (opts == null) throw new ArgumentNullException("opts", "Options of saving is NULL");
            AddEvents(overwrite, e);
            SaveWithoutAdding(overwrite, _events[e.ID], opts);
        }

        /// <summary>
        ///     Adds event to repository and saves it in the way descibed by opts parameter
        /// </summary>
        /// <param name="overwrite">
        ///     Determines whether this event must be overwrited if there already exists such event in the repository.
        /// </param>
        /// <param name="e">
        ///     Event that you want to save.
        /// </param>
        /// <param name="opts">
        ///     Array of options, which describe ways to save event.
        ///     <para>Opts must be following structure: <c>"way1;way2;way3"</c></para>
        /// </param>
        /// <exception cref="System.ArgumentNullException">Throw when <c>opts</c> is <c>null</c></exception>
        public void SaveEvent(bool overwrite, Event e, string opts)
        {
            if (opts == null) throw new ArgumentNullException("opts", "Options of saving is NULL");
            if (opts == "") return;
            SaveEvent(overwrite, e, opts.Split(';'));
        }

        /// <summary>
        ///     Saves all added earlier and stored locally events in the way descibed by opts parameter
        /// </summary>
        /// <param name="deleteLocal">
        ///     Determines whether locally stored events must be deleted or not.
        /// </param>
        /// <param name="overwrite">
        ///     Determines whether this event must be overwrited if there already exists such event in the repository.
        /// </param>
        /// <param name="opts">
        ///     Array of options, which describe ways to save event.
        /// </param>
        /// <exception cref="System.ArgumentNullException">Throw when <c>opts</c> is <c>null</c></exception>
        public void SaveAllEvents(bool deleteLocal, bool overwrite, params string[] opts)
        {
            if (opts == null) throw new ArgumentNullException("opts", "Options of saving is NULL");
            foreach (Event e in _events.Values)
            {
                SaveWithoutAdding(overwrite, e, opts);
            }
            if (deleteLocal) _events.Clear();
        }

        /// <summary>
        ///     Saves all added earlier and stored locally events in the way descibed by opts parameter
        /// </summary>
        /// <param name="deleteLocal">
        ///     Determines whether locally stored events must be deleted or not.
        /// </param>
        /// <param name="overwrite">
        ///     Determines whether this event must be overwrited if there already exists such event in the repository.
        /// </param>
        /// <param name="opts">
        ///     Array of options, which describe ways to save event.
        ///     <para>Opts must be following structure: <c>"way1;way2;way3"</c></para>
        /// </param>
        /// <exception cref="System.ArgumentNullException">Throw when <c>opts</c> is <c>null</c></exception>
        public void SaveAllEvents(bool deleteLocal, bool overwrite, string opts)
        {
            if (opts == null) throw new ArgumentNullException("opts", "Options of saving is NULL");
            if (opts == "") return;
            SaveAllEvents(deleteLocal, overwrite, opts.Split(';'));
        }
    }
}
