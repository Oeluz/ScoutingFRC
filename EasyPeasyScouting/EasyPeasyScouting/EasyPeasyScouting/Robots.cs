using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPeasyScouting
{
    public static class Robots
    {
        public static List<Robot> list = new List<Robot>();

        public static void LoadList()
        {
            Robot robot = new Robot("MOI", "00001");

            list.Add(robot);
        }
    }
}
