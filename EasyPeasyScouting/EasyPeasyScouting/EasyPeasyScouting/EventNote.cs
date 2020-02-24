using System;
using System.Collections.Generic;
using System.Text;
/* Author:      Zhencheng Chen
 * Class:       An EventNote class - record the DateTime and The event description then will be added to a robot object's EventList
 * Date:        2/24/2020
 */
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
            return $"{EventName} - {Time:mm:ss:fff}"; //Display in EventList in RobotPage
        }
    }
}
