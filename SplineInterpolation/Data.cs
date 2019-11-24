using System;
using System.Collections.Generic;
using System.Text;

namespace SplineInterpolation
{
    public class Data
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        public double U { get; set; }
        public double V { get; set; }
        public double X { get; set; }

        public Data(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

    }
}
