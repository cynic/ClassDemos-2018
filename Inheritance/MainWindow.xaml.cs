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

namespace Inheritance {
    public class TheBaseClass {
        public TheBaseClass(int value) {
            MainWindow.Output.Text +=
                String.Format("TheBaseClass constructor called, with value {0}\n", value);
        }

        public void SaySomething() {
            MainWindow.Output.Text += "I'm in TheBaseClass's \"SaySomething\" method\n";
        }

        public virtual void Whatever() {
            MainWindow.Output.Text += "I'm in TheBaseClass's \"Whatever\" method\n";
        }
    }

    public class TheDerivedClass : TheBaseClass {
        public TheDerivedClass(string x) : base(77) {
            MainWindow.Output.Text +=
                String.Format("TheDerivedClass constructor called, with value \"{0}\"\n", x);
        }

        public override void Whatever() {
            MainWindow.Output.Text +=
                String.Format("I'm in TheDerivedClass's \"Whatever\" method.\n");
            // I don't NEED to call the base class's Whatever method.
            // But if I WANT to do it, then I can do it this way:
            base.Whatever();
        }
    }

    public partial class MainWindow : Window {
        public static TextBox Output;
        TheBaseClass parent;
        TheDerivedClass child;

        public MainWindow() {
            InitializeComponent();
            Output = output;
            parent = new TheBaseClass(84649);
            child = new TheDerivedClass("MOOOO");
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            output.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            parent.Whatever();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            child.Whatever();
        }
    }
}
