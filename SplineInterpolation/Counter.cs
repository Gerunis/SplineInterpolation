using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplineInterpolation
{
    class Counter
    {
        public static Dot[] ReadDots()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());
            var t = new Dot[n];
            Console.WriteLine("X  Y");
            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var e = line.Split(' ').Select(x => Double.Parse(x)).ToArray();
                t[i] = new Dot(e[0], e[1]);
            }
            return t;
        }      

        public static void Thomas(Data[] e)
        {
            var n = e.Length;
            e[0].U = -e[0].C / e[0].B;
            e[0].V = e[0].D / e[0].B;


            for(var i = 1; i < n - 1; i++)
            {
                e[i].U = -e[i].C / (e[i].A * e[i - 1].U + e[i].B);
                
                e[i].V = (e[i].D - e[i].A * e[i - 1].V) /(e[i].A * e[i - 1].U + e[i].B);
            }

            var k = e[n - 1].D - e[n - 1].A * e[n - 2].V;
            var z = e[n - 1].A * e[n - 2].U + e[n - 1].B;
            e[n - 1].X = (k) / (z);
            
            for(var i = 1; i < n; i++)
            {
                var t = e[n - i].X * e[n - 1 - i].U + e[n - 1 - i].V;
                e[n - 1 - i].X = t;
            }
        }
        public static void DrawTable(Data[] table)
        {
            Console.WriteLine("i  a        b        c         d         u         v       x");
            for (var i = 0; i < table.Length; i++)
            {
                Console.WriteLine("{0}  {1:N5}  {2:N5}  {3:N5}  {4:N5}  {5:N5}  {6:N5}  {7:N5}", i, table[i].A, table[i].B, table[i].C, table[i].D, table[i].U, table[i].V, table[i].X);
            }
            Console.WriteLine();
        }

        public static Function[] SplimeCount(Dot[] dots)
        {
            var n = dots.Length - 1;

            var functions = new Function[n + 1];
            for (var i = 1; i < n + 1; i++)
            {
                functions[i] = new Function(dots[i - 1].X, dots[i].X);
                functions[i].A = dots[i - 1].Y;
            }

            var datas = new Data[n - 1];
            for (var i = 2; i <= n; i++)
            {
                var a = i == 2 ? 0 : functions[i - 1].H;
                var b = 2 * (functions[i - 1].H + functions[i].H);
                var c = i == n ? 0 : functions[i + 1].H;
                var d = 3 * ((dots[i].Y - dots[i - 1].Y) / functions[i].H 
                    - (dots[i - 1].Y - dots[i - 2].Y) / functions[i - 1].H);
                datas[i - 2] = new Data(a,b,c,d );
            }

            Thomas(datas);

            for(var i = 0; i < datas.Length; i++)
            {
                functions[i + 2].C = datas[i].X;
            }

            for (var i = 1; i < n; i++)
            {
                functions[i].D = (functions[i + 1].C - functions[i].C) / (3 * functions[i].H);
                functions[i].B = (dots[i].Y - dots[i - 1].Y)/functions[i].H - functions[i].H*(functions[i + 1].C + 2 * functions[i].C) / 3;
            }

            functions[n].D = (- functions[n].C) / (3 * functions[n].H);
            functions[n].B = (dots[n].Y - dots[n - 1].Y) / functions[n].H - functions[n].H * 2 * functions[n].C / 3;

            for (var i = 1; i <= n; i++)
            {
               
                Console.WriteLine("f(x) = " + functions[i]);
            }

            return functions;
        }
    }
}
