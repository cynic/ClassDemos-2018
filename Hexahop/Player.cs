using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hexahop {
    public enum Direction {
        TopRight, BottomRight, Down, BottomLeft, TopLeft, Up
    }

    public class Player {
        private string location = "pack://application:,,,/";
        Canvas c;
        Image i;
        public Player(Canvas c) {
            this.c = c;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public void Jump(Direction d) {
            switch (d) {
                case Direction.TopRight: X++; Y--; break;
                case Direction.BottomRight: X++; Y++; break;
                case Direction.Down: Y+=2; break;
                case Direction.BottomLeft: X--; Y++; break;
                case Direction.TopLeft: X--; Y--; break;
                case Direction.Up: Y-=2; break;
            }
        }
        public void PlaceAt(int x, int y) {
            X = x;
            Y = y;
        }
        public void Draw() {
            if (i == null) {
                i = new Image();
                BitmapImage bmp = new BitmapImage(new Uri(location + "player.png"));
                i.Source = bmp;
                i.Width = 40;
                i.Height = 34;
                Canvas.SetZIndex(i, 1000); // make sure it's always on top of other elements.
                c.Children.Add(i);
            }
            Canvas.SetTop(i, Y*21);
            Canvas.SetLeft(i, X*40);
        }
    }
}
