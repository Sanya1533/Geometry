using System;

namespace Geometry
{
    class Vector
    {
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector(Point start, Point end)
        {
            X = end.X - start.X;
            Y = end.Y - start.Y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        public static Vector operator *(Vector vector, double k)
        {
            var result = new Vector(vector.X * k, vector.Y * k);
            return result;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            var result = new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return vector1 + (-vector2);
        }

        public static Vector operator -(Vector vector)
        {
            return vector * (-1);
        }

        public static Point GetEndPoint(Vector vector, Point point)
        {
            var endPoint = new Point(vector.X + point.X, vector.Y + point.Y);
            return endPoint;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y;
        }

        public static double GetCosBetweenVectors(Vector vector1, Vector vector2)
        {
            return GetScalarProduct(vector1, vector2) / (vector1.Length * vector2.Length);
        }
    }
}
