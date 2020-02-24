using EasyPeasyScouting.MenuItems;
using EasyPeasyScouting.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
/* Author:      Zhencheng Chen
 * Class:       Master-Detail Page, contains three different pages (MatchPage, RecordPage and ManualPage) via a drawer
 * Date:        2/24/2020
 */
namespace EasyPeasyScouting
{

    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> Menu { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Menu = new List<MasterPageItem>();
            Menu.Add(new MasterPageItem() //Display MatchPage
            {
                Title = "Match",
                Icon = "homeicon.png",
                TargetType = typeof(MatchPage)
                
            });
            Menu.Add(new MasterPageItem() //Display RecordPage
            {
                Title = "Records",
                Icon = "contacticon.png",
                TargetType = typeof(RecordPage)
            });
            Menu.Add(new MasterPageItem() //Display ManualPage
            {
                Title = "Manual",
                Icon = "abouticon.png",
                TargetType = typeof(ManualPage)
            });

            navigationDrawerList.ItemsSource = Menu;
            navigationDrawerList.SelectedItem = Menu[0];

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MatchPage))); //Display
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e) //Handle if the user click on the menu item
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
