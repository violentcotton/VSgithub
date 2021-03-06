﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
*此DI非彼DI
*DI: Dependency Injection
*依赖注入（应用）
*DIP: Dependence Inversion Principle
*依赖反转原则（概念）
*
*依赖注入是在依赖反转的概念之上，结合接口和反射机制的一项应用
*/
namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            var sc = new ServiceCollection();
            sc.AddScoped(typeof(ITank), typeof(MiddleTank));
            sc.AddScoped(typeof(IVehicle), typeof(LightTank));
            sc.AddScoped<Driver>();
            var sp = sc.BuildServiceProvider();
            //=====================================
            ITank tank = sp.GetService<ITank>();
            tank.Fire();
            tank.Run();

            var driver = sp.GetService<Driver>();
            driver.Run();
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