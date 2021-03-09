using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    class Triangle
    {
        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Point A { get; private set; }

        public Point B { get; private set; }

        public Point C { get; private set; }

        public double Square
        {
            get
            {
                var a = Point.GetDistanceToPoint(B, C);
                var b = Point.GetDistanceToPoint(A, C);
                var c = Point.GetDistanceToPoint(A, B);
                var p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        public double Perimeter
        {
            get
            {
                var a = Point.GetDistanceToPoint(B, C);
                var b = Point.GetDistanceToPoint(A, C);
                var c = Point.GetDistanceToPoint(A, B);
                return a+b+c;
            }
        }

        public Circle CircumScribedCircle
        {
            get
            {
                var midAB = new Point((A.X + B.X) / 2, (A.Y + B.Y) / 2);
                var midAC = new Point((A.X + C.X) / 2, (A.Y + C.Y) / 2);
                var AB = new Line(A, B);
                var AC = new Line(A, C);
                var perpAB = new Line(midAB, AB.Normal);
                var perpAC = new Line(midAC, AC.Normal);
                var center = Line.GetCrossingPoint(perpAB, perpAC);
                if(center==null)
                {
                    return null;
                }
                return new Circle(center, Point.GetDistanceToPoint(center, A));
            }
        }

        public static Triangle CreateTriangle(Line line1, Line line2, Line line3)
        {
            var p1 = Line.GetCrossingPoint(line1, line2);
            var p2 = Line.GetCrossingPoint(line1, line3);
            var p3 = Line.GetCrossingPoint(line2, line3);
            if(p1==null||p2==null||p3==null)
            {
                return null;
            }
            return new Triangle(p1, p2, p3);
        }
    }
}
