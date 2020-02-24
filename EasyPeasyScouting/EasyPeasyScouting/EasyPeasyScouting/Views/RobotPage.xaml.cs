using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
/* Author:      Zhencheng Chen
 * Class:       Display the information of a robot, also include the option to email the information with the toolbar item
 * Date:        2/24/2020
 */
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
            var robot = (Robot)BindingContext; //Get the robot object from the BindingContext
            try
            {
                var message = new EmailMessage  //Making an email
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

                await Email.ComposeAsync(message); // Show the email in an email app
            }
            catch (FeatureNotSupportedException fbsEx) //not supported? Display an alert
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