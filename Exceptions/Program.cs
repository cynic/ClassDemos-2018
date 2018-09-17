using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                File.OpenRead(@"this? filename is bad/invalid\not-good");
                Console.WriteLine("Hello!");
            } catch (Exception e)
            {
                Console.WriteLine($"I couldn't open the file, because: {e.Message}");
            }
            Console.ReadLine();
        }
    }
}
