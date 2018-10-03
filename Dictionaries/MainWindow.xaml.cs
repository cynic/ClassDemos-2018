using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Dictionaries {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        string fileText = null;

        private void Button_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != true) return; // just exit this method.
            Stream s = ofd.OpenFile();
            StreamReader reader = new StreamReader(s);
            fileText = reader.ReadToEnd();
            output.Text += "Loaded file: " + ofd.FileName + "\n";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            char[] punctuation = new[] { ' ', ';', '.', ':', ',', '\r', '\n', '\'', '"', '!', '?', '‘', '-', '(', ')', '[', ']' };
            string[] splits = fileText.ToLower().Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> counts = new Dictionary<string, int>();
            // count word frequencies.
            foreach (string word in splits) {
                if (counts.ContainsKey(word)) {
                    counts[word]++;
                } else {
                    counts[word] = 1;
                }
            }
            // now print it out.
            foreach (string k in counts.Keys) {
                output.Text += String.Format("{0}: {1}\n", k, counts[k]);
            }
        }
    }
}
