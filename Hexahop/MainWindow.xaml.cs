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

namespace Hexahop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Referee referee;
        Player player;
        User user;
        public MainWindow() {
            InitializeComponent();
            player = new Player(myCanvas);
            referee = new Referee(myCanvas, player);
            referee.StartGame();
            referee.Draw();
            user = new User(referee, player);
        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e) {
            Point p = e.GetPosition(myCanvas);
            user.ChooseBlock(p);
            if (referee.DecideGame() == GameResult.Win) {
                MessageBox.Show("You win!!!");
            }
        }
    }
}
