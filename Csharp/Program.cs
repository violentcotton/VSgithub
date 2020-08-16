using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stuedent stuedent1 = new Stuedent("Lugar", 20, "man") { Name = "Lucas", Age = 90, Sex = "female" };
            Console.WriteLine(stuedent1.Name);
            //int[] a2 = { 1, 2, 3, 4 };
            //IEnumerator ts = a2.GetEnumerator();
            //Stuedent stuedent = null;
            //stuedent.GoToSchool();
        }
       
    }
    class Stuedent
    {
        public Stuedent(string name,int age,string sex)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public void GoToSchool()
        {
            Console.WriteLine("哎呀我去！");
        }
    }
}
