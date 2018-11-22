using System;
using System.Drawing;

namespace ServerSide
{
    class Pt
    { 
        private Point zero = new Point(0, 0);
        public Point Zero
        {
            get { return zero; }
        }

        public Point[] ourpts(Point[] pts)
        {
            Pt pt = new Pt();
            Point x;
            int l = pts.Length;
            for (int i = 0; i < l - 1; i++)
            {
                for (int j = 0; j < l - 1; j++)
                {
                    if (pt.Lenght(pts[j], pt.Zero) > pt.Lenght(pts[j + 1], pt.Zero))
                    {
                        x = pts[j];
                        pts[j] = pts[j + 1];
                        pts[j + 1] = x;
                    }
                }
            }
            return pts;
        }

        public int Rotate(Point a, Point b, Point c)
        {
            return (b.X - a.X) * (c.Y - b.Y) - (b.Y - a.Y) * (c.X - b.X); // if(return > 0) E lies to the left of a->b.
        }

        public bool Intersect(Point A, Point B, Point C, Point D)
        {
            bool flag;
            flag = ((this.Rotate(A, B, C) * this.Rotate(A, B, D)) <= 0 & (this.Rotate(C, D, A) * this.Rotate(C, D, B)) < 0) ? true : false;
            return (flag);
        }

        public double Lenght(Point A, Point B)
        {
            return (Math.Sqrt(((A.X - B.X) * (A.X - B.X)) + ((A.Y - B.Y) * (A.Y - B.Y))));
        }

        public bool NumberofI(Point A, Point B, Point C, Point E)
        {
            int count = 0;

            if (Intersect(A, B, C, E) == true)
                count++;
            if (Intersect(B, C, E, Zero) == true)
                count++;
            if (Intersect(C, A, E, Zero) == true)
                count++;
            return (count % 2 != 0) ? true : false;
        }

        public void Shepard(MyPoint[] mpts)
        {

        }
        public bool Ptlocation(Point A, Point B, Point C, Point E)
        {
            Point[] pts = new Point[3];
            if (Rotate(A, B, E) < 0 || Rotate(A, C, E) > 0)
            {
                return false;
            }
            else
            {
                int p = 1, r = 2, q = 0;
                while ((r - p) > 1)
                {
                    q = (p + r) / 2;
                    pts[0] = A; pts[1] = B; pts[2] = C;
                    if ((Rotate(pts[0], pts[q], E) < 0))
                    {
                        r = q;
                    }
                    else { p = q; }
                }
                if ((Lenght(pts[q], new Point(0, 0)) > Lenght(E, new Point(0, 0)))
                    && (Lenght(pts[p], new Point(0, 0)) > Lenght(E, new Point(0, 0))))
                {
                    return (!(Intersect(pts[0], E, pts[p], pts[r])));
                }
                else
                {
                    if (Rotate(pts[p], pts[q], E) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
