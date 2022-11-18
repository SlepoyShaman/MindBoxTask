using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaLib.Supporting
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public Point GetVectorCords(Point end)
            => new Point(end.X - X, end.Y - Y);

        public double GetVectorLenght(Point end)
        {
            var vectorCords = GetVectorCords(end);
            return Math.Sqrt(vectorCords.X * vectorCords.X + vectorCords.Y * vectorCords.Y);
        }

        public static double ScalarProduct(Point vectorA, Point vectorB)
            => vectorA.X * vectorB.X + vectorA.Y * vectorB.Y;
        public static double VectorProductModule(Point vectorA, Point VectorB)
            => vectorA.X * VectorB.Y - vectorA.Y * VectorB.X;
    }
}
