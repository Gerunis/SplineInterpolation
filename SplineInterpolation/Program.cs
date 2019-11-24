using System;
using System.Linq;

namespace SplineInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = Counter.SplimeCount(Counter.ReadDots());

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
