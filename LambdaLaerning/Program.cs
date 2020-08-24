using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaLaerning
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> funcAdd = ( a, b) => { return a * b; };
            Console.WriteLine(DoSomeCal<int>(funcAdd, 100, 100));

            var res=DoSomeCal((a, b) => { return a + b; }, 100, 100);
            Console.WriteLine(res);
        }

        static T DoSomeCal<T>(Func<T,T,T> func,T a,T b)
        {
            T res = func(a, b);
            return res;
        }
    }
}
