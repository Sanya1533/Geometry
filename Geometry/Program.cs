using System;

using static System.Console;

namespace Geometry
{
    class Program
    {
        static Point GetPoint()
        {
            var data = ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return new Point(double.Parse(data[0]), double.Parse(data[1]));
        }

        static Line GetLine()
        {
            var data = ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return new Line(double.Parse(data[0]), double.Parse(data[1]));
        }

        static Circle GetCircle()
        {
            var data = ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return new Circle(new Point(double.Parse(data[0]), double.Parse(data[1])), double.Parse(data[2]));
        }

        static Segment GetSegment()
        {
            var data = ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return new Segment(new Point(double.Parse(data[0]), double.Parse(data[1])), new Point(double.Parse(data[2]), double.Parse(data[3])));
        }

        static void Main()
        {
        }
    }
}