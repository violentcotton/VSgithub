using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Car();
            vehicle.Run();
        }
    }
    class Vehicle
    {
        public virtual void Run()
        {
            Console.WriteLine("I am Running!");
        }
    }

    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is Running");
            double a = 1.0;
            string s = "abc";
        }
    }
}
