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

        private Dictionary<string,int> WordFrequency() {
            if (fileText == null) {
                throw new InvalidOperationException("You must load a file first.");
            }
            string t = fileText.ToLower();
            string unwanted = " 0123456789!\"#$%&()*+,-./:;<=>?@[]^_`{|}~'\\;\r\n‘’";
            char[] delims = unwanted.ToCharArray();
            string[] splits = t.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> counts = new Dictionary<string, int>();
            // count word frequencies.
            foreach (string word in splits) {
                if (counts.ContainsKey(word)) {
                    counts[word]++;
                } else {
                    counts[word] = 1;
                }
            }
            return counts;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Dictionary<string, int> frequency = WordFrequency();
            // now print it out.
            string to_print = "";
            foreach (string k in frequency.Keys) {
                to_print += String.Format("{0}: {1}\n", k, frequency[k]);
            }
            output.Text = to_print;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            Dictionary<string, int> frequency = WordFrequency();
            Dictionary<int, List<string>> inv = new Dictionary<int, List<string>>();
            foreach (KeyValuePair<string, int> kvp in frequency) {
                if (!inv.ContainsKey(kvp.Value)) {
                    inv[kvp.Value] = new List<string>();
                }
                inv[kvp.Value].Add(kvp.Key);
            }
            // some output now.
            string to_print = "";
            foreach (int n in inv.Keys) {
                string joined = String.Join(", ", inv[n]);
                to_print += String.Format("{0}: {1}\n", n, joined);
            }
            output.Text = to_print;
        }
    }
}
