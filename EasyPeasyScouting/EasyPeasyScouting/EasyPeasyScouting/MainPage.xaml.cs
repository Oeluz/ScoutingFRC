using EasyPeasyScouting.MenuItems;
using EasyPeasyScouting.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyPeasyScouting
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> Menu { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Menu = new List<MasterPageItem>();
            Menu.Add(new MasterPageItem()
            {
                Title = "Match",
                Icon = "homeicon.png",
                TargetType = typeof(MatchPage)
                
            });
            Menu.Add(new MasterPageItem()
            {
                Title = "Records",
                Icon = "contacticon.png",
                TargetType = typeof(RecordPage)
            });
            Menu.Add(new MasterPageItem()
            {
                Title = "Manual",
                Icon = "abouticon.png",
                TargetType = typeof(ManualPage)
            });

            navigationDrawerList.ItemsSource = Menu;
            navigationDrawerList.SelectedItem = Menu[0];

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MatchPage)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
