using System;
using System.Collections.Generic;
using System.Text;

namespace SplineInterpolation
{
    public class Function
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public double H { get => End - Start; }

        public double Start { get; private set; }
        public double End { get; private set; }

        public Function(double start, double end)
        {
            Start = start;
            End = end;
        }

        public double Count(double x)
        {
            return A + B * (x - Start) + C * (x - Start) * (x - Start) + D * (x - Start) * (x - Start) * (x - Start);
        }

        public override string ToString()
        {
            return String.Format("{0:0.0000;- 0.0000} {1:+ 0.0000;- 0.0000}(x - {4}) {2:+ 0.0000;- 0.0000}(x - {4})^2 {3:+ 0.0000;- 0.0000}(x - {4})^3  {4} <= x <= {5}", A,B,C,D,Start, End);
        }

    }
}
