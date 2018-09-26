using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Static {
    public enum AlienState { HandsDown, HandsUp }

    public class Alien {
        static string location = "pack://application:,,,/";
        public int X { get; private set; }
        public int Y { get; private set; }
        static BitmapImage image1 = new BitmapImage(new Uri(location + "alien1.png"));
        static BitmapImage image2 = new BitmapImage(new Uri(location + "alien2.png"));
        // this next one could also have been a static class-level variable.
        // But just for fun, we made it a property...
        public static AlienState Hands { get; set; }
        Image i;
        public Alien(Canvas c, int x, int y) {
            X = x;
            Y = y;
            i = new Image();
            i.Width = 45;
            i.Height = 50;
            c.Children.Add(i);
        }
        public void Draw() {
            // NOTICE: I can access 'hands', 'image1', and 'image2' WITHOUT
            // using the class name here.
            switch (Hands) {
                case AlienState.HandsDown: i.Source = image1; break;
                case AlienState.HandsUp: i.Source = image2; break;
            }
            Canvas.SetTop(i, Y * 60);
            Canvas.SetLeft(i, X * 55);
        }
        public static string GetInternalInfo() {
            string result = String.Format("The hands are {0}, location is {1}", Hands, location);
            return result;
        }
    }

    public partial class MainWindow : Window {
        List<Alien> aliens = new List<Alien>();
        public MainWindow() {
            InitializeComponent();
            for (int i = 0; i < 10; i++) {
                aliens.Add(new Alien(myCanvas, i, 0));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            // Notice: I MUST use the class name here.
            Alien.Hands = AlienState.HandsUp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Alien.Hands = AlienState.HandsDown;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            if (Alien.Hands == AlienState.HandsDown) {
                Alien.Hands = AlienState.HandsUp;
            } else {
                Alien.Hands = AlienState.HandsDown;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            foreach (Alien x in aliens) {
                x.Draw();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            output.Text = Alien.GetInternalInfo();
        }
    }
}
