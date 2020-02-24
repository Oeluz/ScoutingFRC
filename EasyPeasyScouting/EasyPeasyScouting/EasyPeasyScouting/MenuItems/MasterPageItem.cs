using System;
using System.Collections.Generic;
using System.Text;
/* Author:      Zhencheng Chen
 * Class:       A class that contain three different properties that will be used for master detail page (Main Page)
 * Date:        2/24/2020
 */
namespace EasyPeasyScouting.MenuItems
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}
