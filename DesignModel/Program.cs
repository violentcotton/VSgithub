using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle vehicle = new Car();
            vehicle.Run();
        }
    }
    interface IVehicle
    {
         void Run();
         void Stop();
         void Fill();
    }
    abstract class Vehicle: IVehicle
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }
        public  void Fill()
        {
            Console.WriteLine("Pay and fill");
        }

        public abstract void Run();
        
    }
    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }
    class Truck : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running...");
        }
    }
}
//未做基类而生的"抽象类"与"开放/关闭原则"
