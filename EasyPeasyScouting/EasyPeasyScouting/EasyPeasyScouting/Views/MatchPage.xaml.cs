using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
/* Author:      Zhencheng Chen
 * Class:       "Main Page", this page is where the user will record the performance, scores, and many more for a robot
 * Date:        2/24/2020
 */
namespace EasyPeasyScouting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        int screenNum = 0;
        Robot robot;
        bool teleoperated = true;

        int millisecond = 0;
        int second = 0;
        int minute = 0;
        Timer timer;

        public MatchPage()
        {
            InitializeComponent();
            
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e) //event handler
        {
            bool flag = true;
            millisecond++;
            if (millisecond == 100) //if the millisecond reach 100, the interval is 10 which mean per 10 millisecond
            {
                second++;
                millisecond = 0;
            }

            if (second == 60)
            {
                minute++;
                second = 0;
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                TimerLabel.Text = $"{minute:00}:{second:00}:{millisecond:00}";//Constantly updating
            });

            if(second == 15 && flag) //if it reach 15 seconds, the teleoBtn will show up
            {
                TeleoBtn.IsVisible = true;
                flag = false;
            }

            if(minute == 2 && second == 30) //Stop if the timer reach 2 minutes and 30 seconds
            {
                timer.Stop();
            }
        }


        private async void Button_Clicked(object sender, EventArgs e) //Start recording data for a robot
        {
            if (String.IsNullOrWhiteSpace(MatchEntry.Text) || String.IsNullOrWhiteSpace(NameEntry.Text)) //Make sure the name and match is not null
            {
                //if null, show an alert
                await DisplayAlert("Blank Field", "Please enter the name of a robot or the match number.", "Ok"); 
                return;
            }

            //if the match/name is not null
            robot = new Robot(NameEntry.Text, MatchEntry.Text);

            timer = new Timer();
            timer.Interval = 10;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            screenNum++; //Increase the value to 1

            //Hide these views
            StartBtn.IsVisible = false;
            NameEntry.IsVisible = false;
            MatchEntry.IsVisible = false;

            //Show these views for Screen #1
            TimerLabel.IsVisible = true;
            FoulBtn.IsVisible = true;
            InnerBtn.IsVisible = true;
            SubInnerBtn.IsVisible = true;
            UpperBtn.IsVisible = true;
            SubUpperBtn.IsVisible = true;
            BotBtn.IsVisible = true;
            SubBotBtn.IsVisible = true;


        }

        private void PointButton_Clicked(object sender, EventArgs e) //Screen #1 - Add # of scored
        {
            var btn = (Button)sender;

            if(btn == UpperBtn) //Check if the button match
            {
                if(teleoperated) //if teleoperated is true, it will count as "automatic" process
                {
                    robot.DoubleUpPoint++;

                    var note = new EventNote(EventTime(), "Upper Point Scored (2x)");
                    robot.EventList.Add(note);
                }
                else //if teleoperated is false, it will count as "manual" process
                {
                    robot.UpPoint++;
                    var note = new EventNote(EventTime(), "Upper Point Scored");
                    robot.EventList.Add(note);
                }
                //Update the button text
                UpperBtn.Text = "# of Outer Scored: " + (robot.UpPoint + (robot.DoubleUpPoint * 2)).ToString();

            }
            else if(btn == SubUpperBtn)
            {
                if (teleoperated)
                {
                    robot.DoubleUpPoint--;

                    var note = new EventNote(EventTime(), "Upper Point Subtracted (2x)");
                    robot.EventList.Add(note);
                }
                else
                {
                    robot.UpPoint--;

                    var note = new EventNote(EventTime(), "Upper Point Subtracted");
                    robot.EventList.Add(note);
                }

                if (Negative(robot.DoubleUpPoint))
                {
                    robot.DoubleUpPoint = 0;
                }

                if (Negative(robot.UpPoint))
                {
                    robot.UpPoint = 0;
                }

                UpperBtn.Text = "# of Outer Scored: " + (robot.UpPoint + (robot.DoubleUpPoint * 2)).ToString();
            }
            else if (btn == BotBtn)
            {
                if (teleoperated)
                {
                    robot.DoubleLowPoint++;

                    var note = new EventNote(EventTime(), "Bottom Point Scored (2x)");
                    robot.EventList.Add(note);
                }
                else
                {
                    robot.LowPoint++;

                    var note = new EventNote(EventTime(), "Bottom Point Scored");
                    robot.EventList.Add(note);
                }


                BotBtn.Text = "# of Bottom Scored: " + (robot.LowPoint + (robot.DoubleLowPoint * 2)).ToString();
            }
            else if (btn == SubBotBtn)
            {
                if (teleoperated)
                {
                    robot.DoubleLowPoint--;

                    var note = new EventNote(EventTime(), "Bottom Point Subtracted (2x)");
                    robot.EventList.Add(note);
                }
                else
                {
                    robot.LowPoint--;

                    var note = new EventNote(EventTime(), "Bottom Point Subtracted");
                    robot.EventList.Add(note);
                }

                if (Negative(robot.DoubleLowPoint))
                {
                    robot.DoubleLowPoint = 0;
                }

                if (Negative(robot.LowPoint))
                {
                    robot.LowPoint = 0;
                }

                BotBtn.Text = "# of Bottom Scored: " + (robot.LowPoint + (robot.DoubleLowPoint * 2)).ToString();
            }
            else if (btn == InnerBtn)
            {
                if (teleoperated)
                {
                    robot.DoubleSmallPoint++;

                    var note = new EventNote(EventTime(), "Inner Point Scored (2x)");
                    robot.EventList.Add(note);
                }
                else
                {
                    robot.SmallPoint++;

                    var note = new EventNote(EventTime(), "Inner Point Scored");
                    robot.EventList.Add(note);
                }

                InnerBtn.Text = "# of Inner Scored: " + (robot.SmallPoint + (robot.DoubleSmallPoint * 2)).ToString();
            }
            else if (btn == SubInnerBtn)
            {
                if (teleoperated)
                {
                    robot.DoubleSmallPoint--;

                    var note = new EventNote(EventTime(), "Inner Point Subtracted");
                    robot.EventList.Add(note);
                }
                else
                {
                    robot.SmallPoint--;

                    var note = new EventNote(EventTime(), "Inner Point Subtracted");
                    robot.EventList.Add(note);
                }

                if (Negative(robot.DoubleSmallPoint))
                {
                    robot.DoubleSmallPoint = 0;
                }

                if (Negative(robot.SmallPoint))
                {
                    robot.SmallPoint = 0;
                }

                InnerBtn.Text = "# of Inner Scored: " + (robot.SmallPoint + (robot.DoubleSmallPoint * 2)).ToString();
            }
            else if (btn == TeleoBtn) //if clicked TeleoBtn
            {
                if (teleoperated) //if teleoperated is true - will enter "manual" process
                {
                    teleoperated = false;
                    TeleoBtn.BackgroundColor = Color.Orange;
                    TeleoBtn.TextColor = Color.White;
                    TeleoBtn.BorderColor = Color.Black;

                    var note = new EventNote(EventTime(), "Switched to Teleoperated Phase");
                    robot.EventList.Add(note);
                }
                else // if teleoperated is false - will enter "automatic" process
                {
                    teleoperated = true;
                    TeleoBtn.BackgroundColor = Color.Black;
                    TeleoBtn.TextColor = Color.White;
                    TeleoBtn.BorderColor = Color.Orange;

                    var note = new EventNote(EventTime(), "Switched back to Teleoperated Phase");
                    robot.EventList.Add(note);
                }
            }
            else if (btn == FoulBtn) // Increase the # of fouls by one
            {
                robot.FoulNum++;
                FoulBtn.Text = "Foul #: " + robot.FoulNum.ToString();

                var note = new EventNote(EventTime(), "This Robot got a foul");
                robot.EventList.Add(note);
            }

        }

        bool Negative(double num) //make sure the number will not go negative, only apply to any button that subtract
        {
            if(num >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e) //Handle the swipe gesture event
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    LeftSwipe(); //if left swipe, call the method
                    break;
                case SwipeDirection.Right:
                    RightSwipe(); //if right swipe, call the method
                    break;
                default:
                    break;
            }
        }
        private void LeftSwipe()
        {
            if(screenNum == 1) //Check the current screen num then decide what to do with it based on the number
            {
                screenNum++;
                ToSecondPageFromFirst(); 
            }
            else if(screenNum == 2)
            {
                screenNum++;
                ToThirdPageFromSecond();
            }
        }

        private void RightSwipe() //Check the current screen num then decide what to do with it based on the number
        {
            if (screenNum == 2)
            {
                screenNum--;

                ToFirstPageFromSecond();
            }
            else if (screenNum == 3)
            {
                screenNum--;

                ToSecondPageFromThird();
            }
        }

        private void ToFirstPageFromSecond() //Dumb way to change the "screen" without navigation
        {
            //To First Screen from Second Screen
            InnerBtn.IsVisible = true;
            SubInnerBtn.IsVisible = true;
            UpperBtn.IsVisible = true;
            SubUpperBtn.IsVisible = true;
            BotBtn.IsVisible = true;
            SubBotBtn.IsVisible = true;

            RotaLabel.IsVisible = false;
            RotationSwitch.IsVisible = false;
            PosLabel.IsVisible = false;
            PositionSwitch.IsVisible = false;
            HangLabel.IsVisible = false;
            HangedSwitch.IsVisible = false;
            LevelLabel.IsVisible = false;
            LeveledSwitch.IsVisible = false;
            ParkLabel.IsVisible = false;
            ParkedSwitch.IsVisible = false;
            InitatedLabel.IsVisible = false;
            InitatedSwitch.IsVisible = false;
        }

        private void ToSecondPageFromThird()
        {
            //To Second SCreen from Third Screen
            TimerLabel.IsVisible = true;
            
            RotaLabel.IsVisible = true;
            RotationSwitch.IsVisible = true;
            PosLabel.IsVisible = true;
            PositionSwitch.IsVisible = true;
            HangLabel.IsVisible = true;
            HangedSwitch.IsVisible = true;
            LevelLabel.IsVisible = true;
            LeveledSwitch.IsVisible = true;
            ParkLabel.IsVisible = true;
            ParkedSwitch.IsVisible = true;
            InitatedLabel.IsVisible = true;
            InitatedSwitch.IsVisible = true;

            NoteLabel.IsVisible = false;
            NoteEdit.IsVisible = false;
            SaveBtn.IsVisible = false;
        }

        private void ToSecondPageFromFirst()
        {
            //To Second Screen from First Screen
            InnerBtn.IsVisible = false;
            SubInnerBtn.IsVisible = false;
            UpperBtn.IsVisible = false;
            SubUpperBtn.IsVisible = false;
            BotBtn.IsVisible = false;
            SubBotBtn.IsVisible = false;

            RotaLabel.IsVisible = true;
            RotationSwitch.IsVisible = true;
            PosLabel.IsVisible = true;
            PositionSwitch.IsVisible = true;
            HangLabel.IsVisible = true;
            HangedSwitch.IsVisible = true;
            LevelLabel.IsVisible = true;
            LeveledSwitch.IsVisible = true;
            ParkLabel.IsVisible = true;
            ParkedSwitch.IsVisible = true;
            InitatedLabel.IsVisible = true;
            InitatedSwitch.IsVisible = true;
        }

        private void ToThirdPageFromSecond()
        {
            //To Third Screen from Second Screen
            TimerLabel.IsVisible = false;

            RotaLabel.IsVisible = false;
            RotationSwitch.IsVisible = false;
            PosLabel.IsVisible = false;
            PositionSwitch.IsVisible = false;
            HangLabel.IsVisible = false;
            HangedSwitch.IsVisible = false;
            LevelLabel.IsVisible = false;
            LeveledSwitch.IsVisible = false;
            ParkLabel.IsVisible = false;
            ParkedSwitch.IsVisible = false;
            InitatedLabel.IsVisible = false;
            InitatedSwitch.IsVisible = false;

            NoteLabel.IsVisible = true;
            NoteEdit.IsVisible = true;
            SaveBtn.IsVisible = true;
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            //if the save button is clicked, change the robot's bool properties based on the switches
            if (InitatedSwitch.IsToggled)
                robot.Initated = true;
            if (LeveledSwitch.IsToggled)
                robot.Leveled = true;
            if (ParkedSwitch.IsToggled)
                robot.Parked = true;
            if (PositionSwitch.IsToggled)
                robot.PositionCtrl = true;
            if (RotationSwitch.IsToggled)
                robot.RotationCtrl = true;

            robot.Note = NoteEdit.Text; //Assign the value of NoteEdit's text to Note in robot object

            Robots.list.Add(robot); //add the robot object to the list
            await DisplayAlert("Saved!", "The robot is saved to the record", "Ok"); //display the alert to notify the user that the robot is saved


            //Unable to overwrite a file due to permission - unsure how to do it
            //string value = JsonConvert.SerializeObject(Robots.list);
            //File.WriteAllText("data.txt", value);

            Reset(); //No navigation, which mean will call the custom method to "reset" everything to first screen
        }

        private DateTime EventTime() //Check the current timer's value then return that value
        {
            var dt = new DateTime(1, 1, 1, 1, minute, second, millisecond);
            return dt;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e) //Use for the event note
        {
            var obj = (Switch)sender;

            if(obj == InitatedSwitch)
            {
                if (obj.IsToggled)
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot is Initated"));
                else
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot is not Initated"));
            }
            else if(obj == LeveledSwitch)
            {
                if (obj.IsToggled)
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot is leveled with other robot"));
                else
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot is not leveled"));
            }
            else if (obj == ParkedSwitch)
            {
                if (obj.IsToggled)
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot is parked"));
                else
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot is not parked"));

            }
            else if (obj == PositionSwitch)
            {
                if (obj.IsToggled)
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot positioned the control panel"));
                else
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot did not position the control panel"));
            }
            else if (obj == RotationSwitch)
            {
                if (obj.IsToggled)
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot rotated the control panel"));
                else
                    robot.EventList.Add(new EventNote(EventTime(), "This Robot did not rotate the control panel"));
            }
        }

        private void Reset() //Reset everything to first screen
        {
            timer.Stop();

            screenNum = 0;
            teleoperated = true;
            millisecond = 0;
            second = 0;
            minute = 0;

            NameEntry.IsVisible = true;
            MatchEntry.IsVisible = true;
            StartBtn.IsVisible = true;

            NoteLabel.IsVisible = false;
            NoteEdit.IsVisible = false;
            SaveBtn.IsVisible = false;
            TeleoBtn.IsVisible = false;
            FoulBtn.IsVisible = false;

            InitatedSwitch.IsToggled = false;
            HangedSwitch.IsToggled = false;
            LeveledSwitch.IsToggled = false;
            ParkedSwitch.IsToggled = false;
            PositionSwitch.IsToggled = false;
            RotationSwitch.IsToggled = false;

            InnerBtn.Text = "# of Inner Scored: 0";
            UpperBtn.Text = "# of Outer Scored: 0";
            BotBtn.Text = "# of Bottom Scored: 0";
            FoulBtn.Text = "Foul #: 0";

            MatchEntry.Text = string.Empty;
            NameEntry.Text = string.Empty;
            NoteEdit.Text = string.Empty;
        }
    }
}