using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            page.BindingContext = Robots.list[e.ItemIndex];

            RobotLV.SelectedItem = null;

            await Navigation.PushAsync(page);
        }
    }
}