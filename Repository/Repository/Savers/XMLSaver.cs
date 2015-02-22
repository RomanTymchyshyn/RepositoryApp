using System;
using System.Xml.Serialization;
using System.IO;

namespace Repository.Savers
{
    /// <summary>
    /// Class that allows you to serialize events to xml file.
    /// </summary>
    public class XMLSaver : ISaver
    {
        private string _directoryName;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="directoryName">Name of the directory in which will be created files with serialized events</param>
        public XMLSaver(string directoryName)
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            _directoryName = directoryName;
        }

        public void SaveEvents(bool overwrite, params Event[] events)
        {
            if (events == null) throw new ArgumentNullException("events", "Events that you try to add is NULL");
            foreach (Event e in events)
            {
                string name = _directoryName + "\\" + e.ID.ToString() + "-event.xml";
                bool exists = File.Exists(name);
                if (!exists || overwrite)
                {
                    XmlSerializer xmlFormat = new XmlSerializer(e.GetType());
                    e.Status = EventStatus.Saved;
                    using (Stream fStream = new FileStream(name,
                                                            FileMode.Create,
                                                            FileAccess.Write,
                                                            FileShare.None))
                    {
                        xmlFormat.Serialize(fStream, e);
                    }
                }
            }
        }
    }
}
