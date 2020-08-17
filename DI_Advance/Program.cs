using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;



namespace DI_Advance
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            var files = Directory.GetFiles(folder);
            var animalTypes =new List<Type>();

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFrom(file);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    if (t.GetMethod("Voice")!=null)
                    {
                        animalTypes.Add(t);
                    }
                }
            }

            while (true)
            {
                for (int i = 0; i < animalTypes.Count; i++)
                {
                    Console.WriteLine($"{i+1}.{animalTypes[i].Name}");
                }
                Console.WriteLine("=================");
                Console.WriteLine("Please chose one animal");
                int index = int.Parse(Console.ReadLine());
                if (index<1 || index>animalTypes.Count)
                {
                    Console.WriteLine("您输入的有误！");
                    continue;
                }
                Console.WriteLine("Please chose times");
                int times= int.Parse(Console.ReadLine());

                var t = animalTypes[index - 1];
                MethodInfo m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);

                m.Invoke(o, new object[] { times });

            }
        }
    }
}
