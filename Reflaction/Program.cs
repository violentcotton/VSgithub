using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflaction
{
    class Program
    {
        static void Main(string[] args)
        {
            ITank tank = new HeavyTank();
            //========以下都是用反射完成==========
            var t = tank.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo fireMi = t.GetMethod("Fire");
            MethodInfo runMi = t.GetMethod("Run");
            fireMi.Invoke(o, null);
            runMi.Invoke(o, null);
            
        }
    }

    public class Driver
    {
        private IVehicle _vehicle;
        public Driver(IVehicle vehicle)
        {
            this._vehicle = vehicle;
        }
        public void Run()
        {
            _vehicle.Run();
        }
    }
    public interface IVehicle
    {
        void Run();
    }
    public class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running!");
        }
    }
    public class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running!");
        }
    }

    interface IWeapon
    {
        void Fire();
    }

    interface ITank : IVehicle, IWeapon
    {

    }
    public class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ka...");
        }
    }
    public class MiddleTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("Ka! ka! ka!...");
        }
    }
    public class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka!! ka!! ka!!...");
        }
    }


    #region<The killer is not too cold>
    public class WarmKiller : IGentleman, IKiller
    {
        public void Love()
        {
            Console.WriteLine("Let me love you forever");
        }

        void IKiller.Kill()
        {
            Console.WriteLine("I will kill the badguy");
        }


    }

    public interface IGentleman
    {
        void Love();
    }
    public interface IKiller
    {
        void Kill();
    }
}
#endregion