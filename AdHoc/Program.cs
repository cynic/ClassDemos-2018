using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdHoc
{
    class Program
    {
        static void ListLength(List<int> whatever)
        {
            Console.WriteLine("The length of the list is..." + whatever.Count);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            // Here we demonstrate the difference between an empty list
            // and a list that doesn't exist.
            // To show that everything works and there's no trickery,
            // here is a totally normal list with some elements.
            // Remember: we first create the value on the right, then assign it
            // to the name on the left.
            List<int> blah = new List<int>();
            blah.Add(7);
            blah.Add(6);
            blah.Add(88);
            // This is a list that has no elements inside it.
            // Once again, we create the variable on the right, then assign it
            // to the name on the left.
            List<int> zoot = new List<int>();
            // This is a variable that has no list attached to it.
            // "null" is the null reference.  It points to nowhere, and it
            // is an error to try to look at what it points to.
            // Since a list is a reference type, it is OK to assign "null" to it.
            List<int> foo = null;

            ListLength(blah); // Expected: 3, because it has 3 elements.
            ListLength(zoot); // Expected: 0, because it has 0 elements.
            ListLength(foo); // Expected: CRASH! because there's no .Count property on something that doesn't exist!
        }
    }
}
