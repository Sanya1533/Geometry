using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    class Quadrangle
    {
        public Quadrangle(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Point A { get; private set; }

        public Point B { get; private set; }

        public Point C { get; private set; }

        public Point D { get; private set; }

        public Circle CircumScribedCircle
        {
            get
            {
                var triangle = new Triangle(A, B, C);
                var circle = triangle.CircumScribedCircle;
                if(circle==null)
                {
                    return null;
                }
                if(circle.GetPointPosition(D) == PointPosition.OnCircle)
                {
                    return circle;
                }
                return null;
            }
        }
    }
}
