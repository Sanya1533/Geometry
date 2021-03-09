using System;

namespace Geometry
{
    class Line
    {
        public Line(double k, double b)
        {
            B = -1;
            A = k * B;
            C = b * B;
        }

        public Line(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Line(Point point, Vector directiveVector)
        {
            A = directiveVector.Y;
            B = -directiveVector.X;
            C = directiveVector.X * point.Y - directiveVector.Y * point.X;
        }

        public Line(Point point1, Point point2)
        {
            A = point1.Y - point2.Y;
            B = point2.X - point1.X;
            C = point1.X * point2.Y - point2.X * point1.Y;
        }

        public double A { get; private set; }

        public double B { get; private set; }

        public double C { get; private set; }

        public static bool operator ==(Line line1, Line line2)
        {
            var a = line1.A / line2.A;
            var b = line1.B / line2.B;
            var c = line1.C / line2.C;
            if (Math.Abs(a - b) < Constants.EPS && Math.Abs(a - c) < Constants.EPS)
                return true;
            return false;
        }

        public static bool operator !=(Line line1, Line line2)
        {
            var a = line1.A / line2.A;
            var b = line1.B / line2.B;
            var c = line1.C / line2.C;
            if (Math.Abs(a - b) < Constants.EPS || Math.Abs(a - c) < Constants.EPS)
                return true;
            return false;
        }

        public Vector Normal
        {
            get
            {
                return new Vector(A, B);
            }
        }

        public double GetYByX(double x)
        {
            return (-A * x - C) / B;
        }

        public static Point GetCrossingPoint(Line line1, Line line2)
        {
            var tmp1 = line1.A / line1.B - line2.A / line2.B;
            var tmp2 = line2.C / line2.B - line1.C / line1.B;
            if (tmp1 == 0)
            {
                return null;
            }
            var x = tmp2 / tmp1;
            return new Point(x, line1.GetYByX(x));
        }
    }
}
