using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hexahop {
    public class HexagonWhite {
        private string location = "pack://application:,,,/";
        Canvas c;
        Image i;
        public HexagonWhite(Canvas c, int x, int y) {
            this.c = c;
            X = x;
            Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public void Remove() {
            c.Children.Remove(i);
        }
        public void Draw() {
            if (i == null) {
                i = new Image();
                i.Source = new BitmapImage(new Uri(location + "hexagon-white.png"));
                i.Width = 40;
                i.Height = 34;
                c.Children.Add(i);
            }
            Canvas.SetLeft(i, X * 40);
            Canvas.SetTop(i, Y * 21);
        }
    }
}
