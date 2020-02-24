using System;
using System.Collections.Generic;
using System.Text;
/* Author:      Zhencheng Chen
 * Class:       Universal "Storage/Class" where all pages can access for the information of a robot in the list
 * Date:        2/24/2020
 */
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
