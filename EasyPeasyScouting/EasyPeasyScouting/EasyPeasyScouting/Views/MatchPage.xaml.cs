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
        public MatchPage()
        {
            InitializeComponent();

            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
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