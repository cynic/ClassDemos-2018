using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReferenceAndValueTypes {
    public partial class MainWindow : Window {
        #region "Plumbing" code.  Unimportant, really.
        public MainWindow() {
            InitializeComponent();
        }

        public void PrintArray(string arrayName, int[] xs) {
            if (xs == null) {
                textBox1.AppendText(String.Format("{0} is not linked to anything.\n", arrayName));
                return;
            }
            if (xs.Length == 0) {
                textBox1.AppendText(String.Format("{0} is an array with no elements in it.\n", arrayName));
                return;
            }
            // if I'm here, then I know the list must exist, and I know that it has >0 elements in it.
            textBox1.AppendText(String.Format("{0} is an array with these elements: [", arrayName));
            int i = 0;
            while (i < xs.Length) {
                textBox1.AppendText(Convert.ToString(xs[i])); // convert element to a string, and add it to the textbox
                if (i != xs.Length - 1) { // don't put a ", " after the last element!
                    textBox1.AppendText(", ");
                }
                i = i + 1;
            }
            textBox1.AppendText("]\n");
        }

        private void clearTextBox_Click(object sender, RoutedEventArgs e) {
            textBox1.Text = ""; // could also have said textBox1.Clear(), I guess.
        }
        #endregion
        private void Earth(int[] x) {
            x = new int[] { 200 };
        }

        private void Fire(int x) {
            x = 5;
        }

        private void Wind(int[] x) {
            x[0] = 99;
            x = new int[] { 300 };
        }

        private void Water(int[] x) {
            x = new int[] { 400 };
            x[0] = 99;
        }
        #region x
        private void button1_Click(object sender, RoutedEventArgs e) {
            int[] a = new int[] { };
            int[] b = new int[] { -7, 90210, 3110 };
            int[] c = null;
            int[] d = new int[1];
            d[0] = 615;
            PrintArray("a", a);
            PrintArray("b", b);
            PrintArray("c", c);
            PrintArray("d", d);
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            int[] a = new int[] { 10, 8, 19 };
            Earth(a);
            PrintArray("a", a);
        }

        private void button3_Click(object sender, RoutedEventArgs e) {
            int[] a = new int[] { 12, 11 };
            Earth(a);
            Fire(a[0]);
            PrintArray("a", a);
        }

        private void button4_Click(object sender, RoutedEventArgs e) {
            int[] a = new int[] { 14, 16 };
            Wind(a);
            Fire(a[0]);
            PrintArray("a", a);
        }
        #endregion
        private void button5_Click(object sender, RoutedEventArgs e) {
            int[] a = new int[] { 14, 18 };
            Water(a);
            Fire(a[0]);
            PrintArray("a", a);
        }

        private void button6_Click(object sender, RoutedEventArgs e) {
            int[] a = new int[] { 16 };
            int[] z = new int[] { 94, 86 };
            z = a;
            PrintArray("a", a);
            PrintArray("z", z);
        }

        private void button7_Click(object sender, RoutedEventArgs e) {
            int[] a = new int[] { 18, 22 };
            int[] z = new int[] { 65, 13 };
            z = a;
            a = new int[] { 17, 19, 4 };
            PrintArray("a", a);
            PrintArray("z", z);
        }

        private void button8_Click(object sender, RoutedEventArgs e) {
            int[] a = new int[] { 20, 88 };
            int[] z = new int[] { 42 };
            z = a;
            a[1] = 32;
            a = new int[] { 91, 10 };
            PrintArray("a", a);
            PrintArray("z", z);
        }
    }
}
