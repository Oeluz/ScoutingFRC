using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
/* Author:      Zhencheng Chen
 * Class:       A Page that contain the listview with Robots.list as the itemsource
 * Date:        2/24/2020
 */
namespace EasyPeasyScouting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordPage : ContentPage
    {
        public RecordPage()
        {
            this.BindingContext = Robots.list;
            InitializeComponent();
        }

        private async void RobotLV_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var page = new RobotPage();
            page.BindingContext = Robots.list[e.ItemIndex]; //Carry the object to RobotPage

            RobotLV.SelectedItem = null; 

            await Navigation.PushAsync(page);
        }
    }
}