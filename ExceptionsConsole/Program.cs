using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exceptions {
    class Program {
        static void FailAndCatch1() {
            // Here, we will try and catch in one method.
            try {
                File.OpenRead(@"this? filename is bad/invalid\not-good");
                Console.WriteLine("Hello!");
            } catch (Exception e) {
                Console.WriteLine($"I couldn't open the file, because: {e.Message}");
            }
        }

        static void FailAndCatch2() {
            // Here, we will try and catch in one method.
            // But we will catch with a more specific case.
            try {
                File.OpenRead(@"this? filename is bad/invalid\not-good");
                Console.WriteLine("Hello!");
            } catch (Exception e) {
                Console.WriteLine($"I couldn't open the file, because: {e.Message}");
            }
        }

        static int DontFail() {
            return 4;
        }

        static void Main(string[] args) {
            Fail();
            Console.ReadLine();
        }
    }
}
