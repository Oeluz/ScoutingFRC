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
    public partial class MatchPage : ContentPage
    {
        int screenNum = 0;
        Robot robot;
        bool teleoperated = true;


        public MatchPage()
        {
            InitializeComponent();

            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MatchEntry.Text) || String.IsNullOrEmpty(NameEntry.Text))
            {
                await DisplayAlert("Blank Field", "Please enter the name of a robot or the match number.", "Ok");
                return;
            }

            robot = new Robot(NameEntry.Text, MatchEntry.Text);

            screenNum++;

            StartBtn.IsVisible = false;
            NameEntry.IsVisible = false;
            MatchEntry.IsVisible = false;

            TimerLabel.IsVisible = true;
            FoulBtn.IsVisible = true;
            TeleoBtn.IsVisible = true;
            InnerBtn.IsVisible = true;
            SubInnerBtn.IsVisible = true;
            UpperBtn.IsVisible = true;
            SubUpperBtn.IsVisible = true;
            BotBtn.IsVisible = true;
            SubBotBtn.IsVisible = true;
            InitatedLabel.IsVisible = true;
            InitatedSwitch.IsVisible = true;


        }

        private void PointButton_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if(btn == UpperBtn)
            {
                if(teleoperated)
                {
                    robot.DoubleUpPoint++;
                }
                else
                {
                    robot.UpPoint++;
                }

                UpperBtn.Text = "# of Outer Scored: " + (robot.UpPoint + (robot.DoubleUpPoint * 2)).ToString();

            }
            else if(btn == SubUpperBtn)
            {
                if (teleoperated)
                {
                    robot.DoubleUpPoint--;
                }
                else
                {
                    robot.UpPoint--;
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
                }
                else
                {
                    robot.LowPoint++;
                }


                BotBtn.Text = "# of Bottom Scored: " + (robot.LowPoint + (robot.DoubleLowPoint * 2)).ToString();
            }
            else if (btn == SubBotBtn)
            {
                if (teleoperated)
                {
                    robot.DoubleLowPoint--;
                }
                else
                {
                    robot.LowPoint--;
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
                }
                else
                {
                    robot.SmallPoint++;
                }

                InnerBtn.Text = "# of Inner Scored: " + (robot.SmallPoint + (robot.DoubleSmallPoint * 2)).ToString();
            }
            else if (btn == SubInnerBtn)
            {
                if (teleoperated)
                {
                    robot.DoubleSmallPoint--;
                }
                else
                {
                    robot.SmallPoint--;
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
            else if (btn == TeleoBtn)
            {
                if (teleoperated)
                {
                    teleoperated = false;
                }
                else
                {
                    teleoperated = true;
                }
            }
            else if (btn == FoulBtn)
            {
                robot.FoulNum++;
                FoulBtn.Text = "Foul #: " + robot.FoulNum.ToString();
            }

        }

        bool Negative(double num)
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

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    LeftSwipe();
                    break;
                case SwipeDirection.Right:
                    RightSwipe();
                    break;
                default:
                    break;
            }
        }
        private void LeftSwipe()
        {
            if(screenNum == 1)
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

        private void RightSwipe()
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

        private void ToFirstPageFromSecond()
        {
            InnerBtn.IsVisible = true;
            SubInnerBtn.IsVisible = true;
            UpperBtn.IsVisible = true;
            SubUpperBtn.IsVisible = true;
            BotBtn.IsVisible = true;
            SubBotBtn.IsVisible = true;
            InitatedLabel.IsVisible = true;
            InitatedSwitch.IsVisible = true;

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
        }

        private void ToSecondPageFromThird()
        {
            TimerLabel.IsVisible = true;
            TeleoBtn.IsVisible = true;
            FoulBtn.IsVisible = true;
            
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

            NoteLabel.IsVisible = false;
            NoteEdit.IsVisible = false;
            SaveBtn.IsVisible = false;
        }

        private void ToSecondPageFromFirst()
        {
            InnerBtn.IsVisible = false;
            SubInnerBtn.IsVisible = false;
            UpperBtn.IsVisible = false;
            SubUpperBtn.IsVisible = false;
            BotBtn.IsVisible = false;
            SubBotBtn.IsVisible = false;
            InitatedLabel.IsVisible = false;
            InitatedSwitch.IsVisible = false;

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
        }

        private void ToThirdPageFromSecond()
        {
            TimerLabel.IsVisible = false;
            TeleoBtn.IsVisible = false;
            FoulBtn.IsVisible = false;

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

            NoteLabel.IsVisible = true;
            NoteEdit.IsVisible = true;
            SaveBtn.IsVisible = true;
        }

    }
}