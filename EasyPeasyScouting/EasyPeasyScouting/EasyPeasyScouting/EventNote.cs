using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPeasyScouting
{
    public class EventNote
    {
        public DateTime Time { get; set; }
        public string EventName { get; set; }

        public EventNote(DateTime time, string eventName)
        {
            Time = time;
            EventName = eventName;
        }

        public override string ToString()
        {
            return $"{EventName} - {Time:mm:ss:fff}";
        }
    }
}
