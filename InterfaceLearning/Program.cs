using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            //Engine engine = new Engine();
            //Car car = new Car(engine);
            //car.Run(10);
            //Console.WriteLine(car.Speed);
            //var user = new PhoneUser(new NokiaPhone());
            //user.UsePhone();
            Deskfan deskfan = new Deskfan(new PowerSupply());
            
            Console.WriteLine(deskfan.Work());
        }
    }
    #region<紧耦合>
    //class Engine
    //{
    //    public int RPM { get; set; }
    //    public void Work(int gas)
    //    {
    //        this.RPM = 1000 * gas;
    //    }

    //}
    //class Car
    //{
    //    private Engine _engine;
    //    public Car(Engine engine)
    //    {
    //        _engine = engine;
    //    }

    //    public int Speed { get; private set; }
    //    public void Run(int gas)
    //    {
    //        _engine.Work(gas);
    //        this.Speed = _engine.RPM / 100;
    //    }
    //}
    #endregion

    #region<松耦合>
    class PhoneUser
    {
        private IPhone _phone;
        public PhoneUser(IPhone phone)
        {
            this._phone = phone;
        }
        public void UsePhone()
        {
            _phone.Dail();
            _phone.Pickup();
            _phone.Receive();
            _phone.Send();
        }
    }
    interface IPhone
    {
        void Dail();
        void Pickup();
        void Send();
        void Receive();
    }
    class NokiaPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Nokia calling...");
        }

        public void Pickup()
        {
            Console.WriteLine("Hi! This is Tim");
        }

        public void Receive()
        {
            Console.WriteLine("Ericsson ring...");
        }

        public void Send()
        {
            Console.WriteLine("Good evening");
        }
    }
    class EricssonPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Ericsson calling...");
        }

        public void Pickup()
        {
            Console.WriteLine("Hi! This is Jim");
        }

        public void Receive()
        {
            Console.WriteLine("Nokia ring...");
        }

        public void Send()
        {
            Console.WriteLine("Good evening too");
        }
    }
    #endregion
    public interface IPowerSupply
    {
        int GetPower();
    }
    public class PowerSupply:IPowerSupply
    {
        public int GetPower()
        {
            return 100;
        }

    }
    public class Deskfan
    {
        private IPowerSupply _powerSupply;
        public Deskfan(IPowerSupply powerSupply)
        {
            this._powerSupply = powerSupply;
        }
        public string Work()
        {
            int power = _powerSupply.GetPower();
            if (power<=0)
            {
                return "Won't work.";
            }
            else if (power < 100) 
            {
                return "Slow";
            }
            else if(power<200)
            {
                return "Work Fine!";
            }
            else
            {
                return "Waring!";
            }
        }
    }
}
