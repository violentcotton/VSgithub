using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Degegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductFactory productFactory = new ProductFactory();
            //WrapFactory wrapFactory = new WrapFactory();
            //Log log = new Log();

            //Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            //Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

            //Action<Product> action1 = new Action<Product>(log.Logger);

            //Box box1 = wrapFactory.WrapProduct(func1, action1);
            //Box box2 = wrapFactory.WrapProduct(func2, action1);

            //Console.WriteLine(box1.Product.Name);
            //Console.WriteLine(box2.Product.Name);


            Student stu1 = new Student { Id = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student { Id = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student { Id = 3, PenColor = ConsoleColor.Red };

            Action act1 = new Action(stu1.DoSomeHomework);
            Action act2 = new Action(stu2.DoSomeHomework);
            Action act3 = new Action(stu3.DoSomeHomework);

            
            act1.BeginInvoke(null,null);
            act2.BeginInvoke(null, null);
            act3.BeginInvoke(null, null);

            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Main thread {0}",i);
                Thread.Sleep(1000);
            }
            
        }


    }
    
    /// <summary>
    /// 定义一个泛型委托
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    delegate T Dele<T>(T a, T b);
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Box
    {
        public Product Product { get; set; }
    }
    public class WrapFactory
    {
        /// <summary>
        /// 模板方法
        /// </summary>
        /// <param name="getProduct">模板方法套用的模板参数，是一个委托变量</param>
        /// <param name="action">回调方法</param>
        /// <returns></returns>
        public Box WrapProduct(Func<Product> getProduct,Action<Product> action)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();
            if (product.Price>100)
            {
                action.Invoke(product);
            }
            box.Product = product;
            return box;
        }
    }
    public class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 70;
            return product;
        }
        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "ToyCar";
            product.Price = 120;
            return product;
        }
    }
    class Log
    {
        public void Logger(Product product)
        {
            Console.WriteLine("Product '{0}' is create at {1},Pirce is {2}", product.Name, DateTime.UtcNow, product.Price);
        }
    }


    class Student
    {
        public int  Id { get; set; }
        public ConsoleColor PenColor { get; set; }
        public void DoSomeHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = PenColor;
                Console.WriteLine("Student {0} doing homework {1} hours",this.Id,i);
                Thread.Sleep(1000);
            }
        }
    }
}
