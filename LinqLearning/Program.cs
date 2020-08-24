using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = { new Student { Name="Barley", Age=10 , Sex="女" },
                   new Student { Name="Boots", Age=4 , Sex="男"},
                   new Student { Name="Whiskers", Age=6 , Sex="男"} };
            
            bool allStartWithB = students.All(pet =>pet.Name.StartsWith("B"));

            bool anyStartWithB = students.Any(pet => pet.Name.StartsWith("B"));

            Console.WriteLine( "{0} pet Student start with 'B'.",allStartWithB ? "All" : "Not all");
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
}
