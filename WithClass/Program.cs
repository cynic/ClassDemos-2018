using System;

namespace WithClass
{
    public class Animal
    {
        string species;
        public Animal(string species, string sound)
        {
            this.species = species;
            Sound = sound;
        }
        public string Sound { get; private set; }
        public string Speak()
        {
            return Sound + " " + Sound + "!";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal cow = new Animal("taurus", "moo");
            Console.WriteLine("Hello World!");
            Console.WriteLine(cow.Sound);
            //cow.Sound = "woof";
            Console.WriteLine(cow.Speak());
            Console.ReadLine();
        }
    }
}
