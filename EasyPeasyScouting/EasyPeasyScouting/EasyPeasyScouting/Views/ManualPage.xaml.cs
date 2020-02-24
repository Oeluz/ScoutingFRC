using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
/* Author:      Zhencheng Chen
 * Class:       Recieve PDF via a link then display it
 * Date:        2/24/2020
 */
namespace EasyPeasyScouting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManualPage : ContentPage
    {
        public ManualPage()
        {
            InitializeComponent();

            //Link for the manual pdf
            var pdfUrl = "https://firstfrc.blob.core.windows.net/frc2020/Manual/2020FRCGameSeasonManual.pdf";
            var googleUrl = "http://drive.google.com/viewerng/viewer?embedded=true&url=";
            if (Device.RuntimePlatform == Device.iOS) //On IOS
            {
                WebView.Source = pdfUrl;
            }
            else if (Device.RuntimePlatform == Device.Android) // On Android
            {
                WebView.Source = new UrlWebViewSource() { Url = googleUrl + pdfUrl };
            }
        }
    }
}