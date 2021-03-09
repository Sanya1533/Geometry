using System;
using System.Collections.Generic;

namespace Geometry
{
    class Circle
    {
        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public Point Center { get; private set; }

        public double Radius { get; private set; }

        public PointPosition GetPointPosition(Point point)
        {
            var result = Math.Pow(point.X - Center.X, 2) + Math.Pow(point.Y - Center.Y, 2) - Radius * Radius;
            if (Math.Abs(result) < Constants.EPS)
            {
                return PointPosition.OnCircle;
            }
            if (result < 0)
            {
                return PointPosition.InsideCircle;
            }
            return PointPosition.OutsideCircle;
        }

        public static bool operator ==(Circle circle1, Circle circle2)
        {
            return circle1.Center == circle2.Center && circle1.Radius == circle2.Radius;
        }

        public static bool operator !=(Circle circle1, Circle circle2)
        {
            return circle1.Center != circle2.Center || circle1.Radius != circle2.Radius;
        }

        public static List<Point> GetCrossPoints(Circle circle, Line line)
        {
            var answer = new List<Point>();
            var k = -line.A / line.B;
            var m = -line.C / line.B;
            var a = 1 + k * k;
            var b = -2 * circle.Center.X + 2 * k * m - 2 * k * circle.Center.Y;
            var c = circle.Center.X * circle.Center.X + m * m + circle.Center.Y * circle.Center.Y - 2 * m * circle.Center.Y - circle.Radius * circle.Radius;
            var discriminant = b * b - 4 * a * c;
            if (discriminant < 0 && -discriminant < Constants.EPS)
            {
                discriminant = 0;
            }
            if (discriminant >= 0)
            {
                if (discriminant == 0)
                {
                    var x = -b / (2 * a);
                    answer.Add(new Point(x, line.GetYByX(x)));
                }
                else
                {
                    var x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    var x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    answer.Add(new Point(x1, line.GetYByX(x1)));
                    answer.Add(new Point(x2, line.GetYByX(x2)));
                }
            }
            return answer;
        }

        public static List<Line> GetTangentsToCircle(Circle circle, Point point)
        {
            var answer = new List<Line>();
            var deltaX = circle.Center.X - point.X;
            var deltaY = circle.Center.Y - point.Y;
            var a = deltaX * deltaX + circle.Radius * circle.Radius;
            var b = 2 * deltaX * deltaY;
            var c = circle.Radius * circle.Radius - deltaY * deltaY;
            var discriminant = b * b - 4 * a * c;
            if (discriminant < 0 && -discriminant < Constants.EPS)
            {
                discriminant = 0;
            }
            if (discriminant >= 0)
            {
                if (discriminant == 0)
                {
                    var k = -b / (2 * a);
                    answer.Add(new Line(k, point.Y - k * point.X));
                }
                else
                {
                    var k1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    var k2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    answer.Add(new Line(k1, point.Y - k1 * point.X));
                    answer.Add(new Line(k2, point.Y - k2 * point.X));
                }
            }
            return answer;
        }

        public static Line GetJointLine(Circle circle1, Circle circle2)
        {
            var a = 2 * (circle2.Center.X - circle1.Center.X);
            var b = 2 * (circle2.Center.Y - circle1.Center.Y);
            var c = circle1.Center.X * circle1.Center.X - circle2.Center.X * circle2.Center.X +
                circle1.Center.Y * circle1.Center.Y - circle2.Center.Y * circle2.Center.Y +
                circle2.Radius * circle2.Radius - circle1.Radius * circle1.Radius;
            return new Line(a, b, c);
        }

        public static List<Point> GetCrossPoints(Circle circle1, Circle circle2)
        {
            if(circle1==circle2)
            {
                return null;
            }
            var line = GetJointLine(circle1, circle2);
            return GetCrossPoints(circle1, line);
        }

        public static List<Line> GetJointTangents(Circle circle1, Circle circle2)
        {
            if (circle1 == circle2)
                return null;
            List<Line> answer = new List<Line>();
            for(int i=-1;i<=1;i+=2)
            {
                for(int j=-1;j<=1;j+=2)
                {
                    var line = CalculateTangents(circle2.Center - circle1.Center, circle1.Radius * i, circle2.Radius * j);
                    if(line!=null)
                    {
                        bool contains = false;
                        foreach(var ans in answer)
                        {
                            if(ans==line)
                            {
                                contains = true;
                                break;
                            }
                        }
                        if(!contains)
                        {
                            answer.Add(line);
                        }
                    }
                }
            }
            for(int i=0;i<answer.Count;i++)
            {
                var c = answer[i].C - answer[i].A * circle1.Center.X - answer[i].B * circle1.Center.Y;
                answer[i] = new Line(answer[i].A, answer[i].B, c);
            }
            return answer;
        }

        private static Line CalculateTangents(Point p, double r1, double r2)
        {
            double r = r2 - r1;
            double z = p.X * p.X + p.Y * p.Y;
            double d = z - r * r;
            if (d < -Constants.EPS)
                return null;
            d = Math.Sqrt(Math.Abs(d));
            var a = (p.X * r + p.Y * d) / z;
            var b = (p.Y * r - p.X * d) / z;
            var c = r1;
            return new Line(a, b, c);
        }
    }
}
