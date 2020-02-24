using System;
using System.Collections.Generic;
using System.Text;
/* Author:      Zhencheng Chen
 * Class:       A Robot class that is able to generate an Robot object
 * Date:        2/24/2020
 */
namespace EasyPeasyScouting
{
    public class Robot
    {
        public string Name { get; set; }
        public string MatchNum { get; set; }
        public string Note { get; set; }
        public bool Initated { get; set; }
        public bool Hanged { get; set; }
        public bool Leveled { get; set; }
        public bool Parked { get; set; }
        public bool RotationCtrl { get; set; }
        public bool PositionCtrl { get; set; }
        public int DoubleLowPoint { get; set; }
        public int DoubleUpPoint { get; set; }
        public int DoubleSmallPoint { get; set; }
        public int LowPoint { get; set; }
        public int UpPoint { get; set; }
        public int SmallPoint { get; set; }
        public int FoulNum { get; set; }
        public List<EventNote> EventList { get; set; }

        public Robot(string name, string matchNum)
        {
            Name = name;
            MatchNum = matchNum;
            Note = String.Empty;
            Initated = false;
            Hanged = false;
            Leveled = false;
            Parked = false;
            RotationCtrl = false;
            PositionCtrl = false;
            DoubleLowPoint = 0;
            DoubleUpPoint = 0;
            DoubleSmallPoint = 0;
            LowPoint = 0;
            UpPoint = 0;
            SmallPoint = 0;
            FoulNum = 0;
            EventList = new List<EventNote>();
        }
    }
}
