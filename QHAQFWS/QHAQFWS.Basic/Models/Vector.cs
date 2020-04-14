using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Basic.Models
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Angle { get; set; }
        public double Length { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
            Angle = Math.Atan2(y, x);
            Length = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public Vector(double angle, double length, bool isRadian)
        {
            if (isRadian)
            {
                Angle = angle;
            }
            else
            {
                Angle = angle / 180 * Math.PI;
            }
            Length = length;
            X = length * Math.Cos(Angle);
            Y = length * Math.Sin(Angle);
        }

        public double GetDegree()
        {
            double t = Angle / Math.PI * 180;
            if (t < 0) t += 360;
            return t;
        }
    }
}
