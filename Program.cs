using System;
using System.Reflection;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dog = Activator.CreateInstance(typeof(Dog)) as Dog;

            PropertyInfo[] properties = dog.GetType().GetProperties();

            PropertyInfo numberOfLegsproperty1 = properties[0];

            PropertyInfo numberOfLegsproperty2 = null;

            foreach(PropertyInfo pi in properties)
            {
                if(pi.Name.Equals("NumberOfLegs", StringComparison.CurrentCultureIgnoreCase))
                {
                    numberOfLegsproperty2 = pi;
                }
            }

            numberOfLegsproperty1.SetValue(dog, 2, null);

            Console.WriteLine(numberOfLegsproperty2.GetValue(dog, null));

        }
    }


    public class Dog
    {
        public int NumberOfLegs { get; set; }

        public Dog()
        {
            NumberOfLegs = 4;
        }

        public Dog(int legs)
        {
            NumberOfLegs = legs;
        }
    }
}
