using System;

namespace Repository
{
    public enum EventType { Error, Warning, Info };
    public enum EventStatus { New, Saved };

    [Serializable]
    public class Event
    {
        #region Fields
        private int _id;

        private string _name;

        private EventType _type;

        private EventStatus _status;

        private string _description;
        #endregion

        #region Properties
        public int ID
        {
            get { return _id; }
            set 
            { 
                /* I think it is not logically to change id after creation. 
                 * But it is required for XmlSerializer.*/
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                /* I think it is not logically to change name after creation. 
                 * But it is required for XmlSerializer.*/
            }
        }

        public EventType Type
        {
            get { return _type; }
            set
            {
                /* I think it is not logically to change type after creation. 
                 * But it is required for XmlSerializer.*/
            }
        }

        public EventStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                //we made this checking, because its not logical
                //to change status of the event from "Saved" to "New"
                if (_status != EventStatus.Saved)
                {
                    _status = value;
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region CTORS
        public Event()
        {
            _id = int.MaxValue;
            _name = "DefaultName";
            _type = EventType.Info;
            _description = "";
            _status = EventStatus.New;
        }

        public Event(int id, string name = "",
                    EventType type = EventType.Info, string description = "")
        {
            _id = id;
            _name = name;
            _type = type;
            _description = description;
            _status = EventStatus.New;
        }
        #endregion
    }
}
