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

namespace Interfaces {
    public interface IAdvisor {
        string GiveAdvice();
    }

    public class Mother : IAdvisor {
        public string GiveAdvice() {
            return "Clean your room.";
        }

        public string Hug(string name) {
            return String.Format("Mum hugs {0}", name);
        }
    }

    public class Book : IAdvisor {
        public string GiveAdvice() {
            return "Set some goals.";
        }
    }

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void PrintAdviceFrom(IAdvisor source) {
            output.Text += source.GiveAdvice() + "\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            IAdvisor x = new Mother();
            PrintAdviceFrom(x);
            // can I use: x.Hug("me")?
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Mother x = new Mother();
            PrintAdviceFrom(x);
            // can I use: x.Hug("me")?
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            Book x = new Book();
            PrintAdviceFrom(x);
        }
    }
}
