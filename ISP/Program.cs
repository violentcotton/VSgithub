using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num1 = { 1, 2, 3, 4, 5 };
            ArrayList num2 = new ArrayList { 1, 2, 3, 4, 5 };
            var roc = new ReadOnlyCollection(num1);
            Console.WriteLine(Sum(num1));
            Console.WriteLine(Sum(num2));
            Console.WriteLine(Sum(roc));


            var driver = new Driver(new HeavyTank());
            driver.Run();


            var warmkiller = new WarmKiller();
            warmkiller.Love();

            IKiller killer = new WarmKiller();
            killer.Kill();
            var warm = killer as WarmKiller;
            warm.Love();
        }
        static int Sum(IEnumerable nums)
        {
            int sum = 0;
            foreach (var n in nums)
            {
                sum += (int)n;
            }

            return sum;
        }
    }
    class ReadOnlyCollection : IEnumerable
    {
        private int[] _array;

        public ReadOnlyCollection(int[] array)
        {
            _array = array;
        }
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public class Enumerator : IEnumerator
        {

            private ReadOnlyCollection _collection;
            private int _head;

            public Enumerator(ReadOnlyCollection collection)
            {
                _collection = collection;
                _head = -1;
            }

            public object Current
            {
                get
                {
                    object o = _collection._array[_head];
                    return o;
                }
            }

            public bool MoveNext()
            {
                if (++_head<_collection._array.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _head = -1;
            }
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

    #endregion
}
