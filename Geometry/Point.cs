using System;

namespace Geometry
{
    class Point
    {
        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public static Point operator +(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        public static Point operator -(Point point1, Point point2)
        {
            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }

        public static bool operator==(Point point1, Point point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return point1.X != point2.X || point1.Y != point2.Y;
        }

        public static double GetDistanceToPoint(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public static double GetDistanceToLine(Point point, Line line)
        {
            var numerator = Math.Abs(line.A * point.X + line.B + point.Y + line.C);
            var denominator = Math.Sqrt(line.A * line.A + line.B * line.B);
            return numerator * denominator;
        }

        public static ProjectionPosition GetProjectionToSegment(Point point, Segment segment)
        {
            Vector vector1 = new Vector(segment.Start, segment.End);
            Vector vector2 = new Vector(segment.Start, point);
            Vector vector3 = new Vector(segment.End, segment.Start);
            Vector vector4 = new Vector(segment.End, point);
            if (Vector.GetCosBetweenVectors(vector1, vector2) < 0 || Vector.GetCosBetweenVectors(vector3, vector4) < 0)
            {
                return ProjectionPosition.Outside;
            }
            return ProjectionPosition.Inside;
        }

        public static Point GetSymmetricalPoint(Point point, Line line)
        {
            var perpendicularLine = new Line(point, line.Normal);
            var crossPoint = Line.GetCrossingPoint(perpendicularLine, line);
            var vector = new Vector(point, crossPoint);
            vector *= 2;
            return Vector.GetEndPoint(vector, point);
        }
    }
}
