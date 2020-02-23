using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace EasyPeasyScouting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RobotPage : ContentPage
    {
        public RobotPage()
        {
            InitializeComponent();
        }

        private async void EmailBtn_Clicked(object sender, EventArgs e)
        {
            var robot = (Robot)BindingContext;
            try
            {
                var message = new EmailMessage
                {
                    Subject = robot.Name + " - Scouting",
                    Body = $"Name: {robot.Name}\n" +
                    $"Match #: {robot.MatchNum}\n" +
                    $"Initated: {robot.Initated}\n" +
                    $"Hanged: {robot.Hanged}\n" +
                    $"Leveled: {robot.Leveled}\n" +
                    $"Parked: {robot.Parked}\n" +
                    $"Rotation: {robot.RotationCtrl}\n" +
                    $"Position: {robot.PositionCtrl}\n" +
                    $"# of Bottom Scored (2x): {robot.DoubleLowPoint}\n" +
                    $"# of Bottom Scored: {robot.LowPoint}\n" +
                    $"# of Upper Scored (2x): {robot.DoubleUpPoint}\n" +
                    $"# of Upper Scored : {robot.UpPoint}\n" +
                    $"# of Inner Scored (2x): {robot.DoubleSmallPoint}\n" +
                    $"# of Inner Scored : {robot.SmallPoint}\n" +
                    $"# of Fouls: {robot.FoulNum}\n\n" +
                    $"Note: \n{robot.Note}\n"
                };

                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await DisplayAlert("Not Supported", fbsEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

    }
}