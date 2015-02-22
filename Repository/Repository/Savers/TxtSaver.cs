using System;
using System.IO;
using System.Reflection;

namespace Repository.Savers
{
    /// <summary>
    /// Class that allows you to save events to txt file.
    /// </summary>
    public class TxtSaver : ISaver
    {
        private string _directoryName;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="directoryName">Name of the directory in which will be created files with saved events</param>
        public TxtSaver(string directoryName)
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            _directoryName = directoryName;
        }

        public void SaveEvents(bool overwrite, params Event[] events)
        {
            if (events == null) throw new ArgumentNullException("events", "Events that you try to add is NULL");
            foreach(Event e in events)
            {
                string name = _directoryName + "\\" + e.ID.ToString() + "-event.txt";
                if (!File.Exists(name) || overwrite)
                {
                    e.Status = EventStatus.Saved;
                    using (StreamWriter sw =
                            File.CreateText(name))
                    {
                        sw.WriteLine("Fields:");
                        FieldInfo[] fields = e.GetType().GetFields();
                        for (int i = 0; i < fields.Length; ++i)
                        {
                            sw.WriteLine("Name: {0}; Type: {1}; Value: {2}", fields[i].Name, fields[i].FieldType, fields[i].GetValue(e).ToString());
                        }
                        sw.WriteLine("Properties:");
                        PropertyInfo[] props = e.GetType().GetProperties();
                        for (int i = 0; i < props.Length; ++i)
                        {
                            sw.WriteLine("Name: {0}; Type: {1}; Value: {2}", props[i].Name, props[i].PropertyType, props[i].GetValue(e).ToString());
                        }
                    }
                }
            }
        }
    }
}
