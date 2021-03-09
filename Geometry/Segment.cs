using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    class Segment
    {
        public Segment(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Point Start { get; private set; }

        public Point End { get; private set; }

        public static Segment GetSymmetricalSegment(Segment segment, Point point)
        {
            Vector vector1 = new Vector(segment.Start, point);
            Vector vector2 = new Vector(segment.End, point);
            vector1 *= 2;
            vector2 *= 2;
            return new Segment(Vector.GetEndPoint(vector1, segment.Start), Vector.GetEndPoint(vector2, segment.End));
        }
    }
}
