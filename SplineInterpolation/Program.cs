using System;
using System.Linq;

namespace SplineInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = Counter.SplimeCount(Counter.ReadDots());
            Console.Write("x = ");
            var n = Console.ReadLine();
            double x;
            while (double.TryParse(n, out x))
            {
                if(x < f[1].Start)
                {
                    Console.WriteLine("X меньше начала отезка");
                }
                else if(x > f[f.Length - 1].End)
                {
                    Console.WriteLine("X больше конца отезка");
                }
                else
                {
                    for(var i = 1; i < f.Length; i++)
                    {
                        if (x <= f[i].End)
                        {
                            Console.WriteLine("F({0}) = {1}", x, f[i].Count(x));
                            Console.WriteLine();
                            break;
                        }
                    }
                }
                Console.Write("x = ");
                n = Console.ReadLine();
            }
            //for(var i = 1; i < f.Length; i++)
            //{
            //    for(var j = f[i].Start; j <= f[i].End; j += 0.01)
            //    {
            //        Console.WriteLine("({0};{1:0.0000})", j, f[i].Count(j));
            //    }
            //}

        }
    }
}
