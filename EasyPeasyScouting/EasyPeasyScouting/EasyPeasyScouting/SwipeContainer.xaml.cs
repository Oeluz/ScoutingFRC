using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
/* Author:      Zhencheng Chen
 * Class:       Provide a view in MatchPage that function as a "view" that allow the users to swipe since Grid doesn't provide gesture recognizer
 * Date:        2/24/2020
 */
namespace EasyPeasyScouting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeContainer : ContentView
    {
        public event EventHandler<SwipedEventArgs> Swipe;
        public SwipeContainer()
        {
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Left));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Right));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Up));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Down));
        }

        SwipeGestureRecognizer GetSwipeGestureRecognizer(SwipeDirection direction)
        {
            var swipe = new SwipeGestureRecognizer { Direction = direction };
            swipe.Swiped += (sender, e) => Swipe?.Invoke(this, e);
            return swipe;
        }
    }
}