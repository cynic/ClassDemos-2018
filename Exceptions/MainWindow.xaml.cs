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
using System.IO;

namespace Exceptions {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void MethodThatCausesAnException() {
            File.OpenRead(@"c:\Yo dawg"); // this file doesn't exist
            MessageBox.Show("Hello there");
        }

        private void TryingAndCatchingInTheSameMethod() {
            try {
                File.OpenRead(@"c:\Yo dawg");
            } catch (FileNotFoundException e) {
                MessageBox.Show("I couldn't find that file, sorry!  " + e.Message);
            }
        }

        private void TryingAndCatchingInOrder() {
            try {
                File.OpenRead(@"c:\Yo dawg");
            } catch (FileNotFoundException e) {
                MessageBox.Show("I can't find that file!");
            } catch (IOException e) {
                MessageBox.Show("Some kind of Input/Output exception happened: " + e.Message);
            }
        }

        private void TryingAndCatchingNonMatchingExceptions() {
            try {
                File.OpenRead(@"c:\Yo dawg");
            } catch (ArgumentException e) {
                MessageBox.Show("Woof!");
            } catch (ArithmeticException e) {
                MessageBox.Show("Meow!");
            }
        }

        private void CatchingAnExceptionInAMethodThatIsCalledFromThisMethod() {
            try {
                MethodThatCausesAnException();
            } catch (IOException e) {
                MessageBox.Show("I caught the exception: " + e.Message);
                MessageBox.Show("The exception happened here: " + e.StackTrace);
            }
        }

        private void SomethingBadWillHappen() {
            MessageBox.Show("I'm about to call something dangerous");
            MethodThatCausesAnException();
            MessageBox.Show("OH NO!!");
        }

        private void CatchingAnExceptionThatOccursTwoMethodsDown() {
            try {
                SomethingBadWillHappen();
            } catch (FileNotFoundException e) {
                MessageBox.Show("I caught the exception, it was here: " + e.StackTrace);
            }
        }

        private void ThrowingAndCatchingOurOwnException(int x) {
            try {
                if (x > 0) {
                    throw new ArgumentException("I'm positive that this value is incorrect!");
                }
            } catch (Exception etc) {
                MessageBox.Show("Got an exception: " + etc.Message);
            }
        }

        private void BeingUnableToCatchThisException() {
            try {
                BeingUnableToCatchThisException();
            } catch (StackOverflowException e) {
                MessageBox.Show("The stack is overflowing!  But I caught it!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MethodThatCausesAnException();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            TryingAndCatchingInTheSameMethod();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            TryingAndCatchingInOrder();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            TryingAndCatchingNonMatchingExceptions();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            CatchingAnExceptionInAMethodThatIsCalledFromThisMethod();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) {
            CatchingAnExceptionThatOccursTwoMethodsDown();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) {
            ThrowingAndCatchingOurOwnException(99);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) {
            BeingUnableToCatchThisException();
        }
    }
}
