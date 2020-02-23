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
    public partial class ManualPage : ContentPage
    {
        public ManualPage()
        {
            InitializeComponent();

            var pdfUrl = "https://firstfrc.blob.core.windows.net/frc2020/Manual/2020FRCGameSeasonManual.pdf";
            var googleUrl = "http://drive.google.com/viewerng/viewer?embedded=true&url=";
            if (Device.RuntimePlatform == Device.iOS)
            {
                WebView.Source = pdfUrl;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                WebView.Source = new UrlWebViewSource() { Url = googleUrl + pdfUrl };
            }
        }
    }
}