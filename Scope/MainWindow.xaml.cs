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

namespace Scope {
    public class ScopeTest {
        public string Name { get; private set; }
        public ScopeTest() {
            Name = "Fred";
        }

        public void Test1(string Name) {
            Name = Name; // Inner scope beats outer scope.
        }

        public void Test2(int Name) {
            // the type of a name in an inner scope doesn't have to be the same
            // as the type of the same name in an outer scope.
            int k = Name;
        }

        public void Test3() {
            for (int i = 0; i < 5; i++) {
                int Name = 88;
            }
            Name = "What?";
            {
                string Name = "moo";
            }
        }
    }

    public partial class MainWindow : Window {
        ScopeTest test = new ScopeTest();
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            test.Test1("Hello");
            output.Text = test.Name;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            test.Test2(987);
            output.Text = test.Name;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            test.Test3();
            output.Text = test.Name;
        }

    }
}
