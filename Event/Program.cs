using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayTheBill();
        }
        
    }
    public class OrderEventArgs:EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs orderEventArgs);
    public class Customer
    {
        private OrderEventHandler OrderEventHandler;
        public event OrderEventHandler Order
        {
            add
            {
                this.OrderEventHandler += value;
            }
            remove
            {
                this.OrderEventHandler -= value;
            }
        }
        public double Bill { get; set; }
        public void PayTheBill()
        {
            Console.WriteLine("I pay Bill ${0}",this.Bill);
        }
        public void WalkIn()
        {
            Console.WriteLine("Walk in the res");
        }
        public void SitDown()
        {
            Console.WriteLine("Sit Down");
        }
        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thinking...");
                Thread.Sleep(1000);
            }
            if (this.OrderEventHandler!=null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "dapanji";
                e.Size = "lager";
                this.OrderEventHandler(this, e);
            }
        }
        public void Action()
        {
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }
    public class Waiter
    {
        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I wish the {0}",e.DishName);
            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price *= 1.0;
                    break;
                case "lager":
                    price *= 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
}
