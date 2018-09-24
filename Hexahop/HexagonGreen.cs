using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hexahop {
    public enum HexagonState {
        Unbroken, Cracked, Broken
    }

    public class HexagonGreen {
        private string location = "pack://application:,,,/";
        Canvas c;
        Image i;
        public HexagonState State { get; private set; }
        public HexagonGreen(Canvas c, int x, int y) {
            this.c = c;
            X = x;
            Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public void Remove() {
            c.Children.Remove(i);
        }
        private BitmapImage CorrectImage() {
            switch (State) {
                case HexagonState.Broken:
                    return new BitmapImage(new Uri(location + "hexG-broken.png"));
                case HexagonState.Cracked:
                    return new BitmapImage(new Uri(location + "hexG-cracked.png"));
                case HexagonState.Unbroken:
                    return new BitmapImage(new Uri(location + "hexG-unbroken.png"));
                default:
                    throw new InvalidOperationException("HexagonState value is incorrect");
            }
        }
        public void Dissolve() {
            switch (State) {
                case HexagonState.Unbroken: State = HexagonState.Cracked; break;
                default: State = HexagonState.Broken; break;
            }
        }
        public void Draw() {
            if (i == null) {
                i = new Image();
                i.Width = 40;
                i.Height = 34;
                c.Children.Add(i);
            }
            i.Source = CorrectImage();
            Canvas.SetLeft(i, X * 40);
            Canvas.SetTop(i, Y * 21);
        }
    }
}
