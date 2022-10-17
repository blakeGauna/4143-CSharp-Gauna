
using System.Windows.Forms;

namespace Quadrilaterals
{
    abstract public class Quadrilateral
    {
        protected PClass x1y1;
        protected PClass x2y1;
        protected PClass x1y2;
        protected PClass x2y2;
        public Quadrilateral()
        {
            x1y1 = new PClass(0, 0);
            x2y2 = new PClass(0, 0);
        }

        //Returns Perimeter
        //virtual because trapezoid uses another method to find perimeter,
        //but all the other classes will use this method.
        public virtual int Perimeter()
        {
            int length = ReturnLength();
            int width = ReturnWidth();
            return (2 * length) + (2 * width);
        }

        //Virtual Area Method
        //virtual because trapezoid uses another method to find area,
        //but all the other classes will use this method.
        public virtual double Area()
        {
            int length = ReturnLength();
            int width = ReturnWidth();
            return width * length;
        }

        //Returns Length
        public int ReturnLength()
        {
            int length = 0;
            if (x1y1.GetX() > x2y1.GetX())
            {
                length = x1y1.GetX() - x2y1.GetX();
            }
            else if (x1y1.GetX() < x2y1.GetX())
            {
                length = x2y2.GetX() - x1y2.GetX();
            }
            return length;
        }

        //Returns width
        public int ReturnWidth()
        {
            int width = 0;
            if (x1y1.GetY() > x1y2.GetY())
                width = x1y1.GetY() - x1y2.GetY();
            else if (x1y1.GetY() < x1y2.GetY())
                width = x2y2.GetY() - x1y1.GetY();
            return width;
        }
        //Return top left point
        public string TopLeft()
        {
            return x1y2.ToString();
        }
        //Return top right point
        public string TopRight()
        {
            return x2y2.ToString();
        }
        //Return bottom left point
        public string BottomLeft()
        {
            return x1y1.ToString();
        }
        //Return bottom right point
        public string BottomRight()
        {
            return x2y1.ToString();
        }

    }

    //Square Class
    public class Square : Quadrilateral
    {
        public Square(PClass p1, PClass p4)
        {
            x1y1 = p1;  //point 1
            x2y2 = p4;  //point 4
            x2y1 = new PClass(p4.GetX(), p1.GetY()); //point 2
            x1y2 = new PClass(p1.GetX(), p4.GetY()); //point 3
        }

    }

    //Rectangle Class
    public class Rectangle : Square
    {
        //Exact same everything pretty much as a square, so we
        //can use the same methods from Square, except we need
        //Rectangle to build a reference to a rectangle object.

        public Rectangle(PClass p1, PClass p4) : base(p1, p4)
        {

        }
    }

    //Parallelagram Class
    public class Parallelagram : Quadrilateral
    {
        //Also pretty much exact same everything as a Square, but
        //we need all 4 points instead of 2. We can use the same 
        //methods to find perimeter and area.
        public Parallelagram(PClass p1, PClass p2, PClass p3, PClass p4)
        {
            x1y1 = p1;
            x2y1 = p2;
            x1y2 = p3;
            x2y2 = p4;
        }

    }

    //Trapezoid Class
    public class Trapezoid : Quadrilateral
    {
        public Trapezoid(PClass p1, PClass p2, PClass p3, PClass p4)
        {
            x1y1 = p1;
            x2y1 = p2;
            x1y2 = p3;
            x2y2 = p4;
        }

        //Finding all the sides and returning perimeter
        public override int Perimeter()
        {
            int s1, s2, s3, s4 = 0;
            s1 = x2y1.GetX() - x1y1.GetX();
            s2 = x2y2.GetX() - x1y2.GetX();
            s3 = x1y2.GetY() - x1y1.GetY();
            s4 = x2y2.GetY() - x2y1.GetY();
            return s1 + s2 + s3 + s4;
        }

        //Area of a trapezoid: 1/2*h(b1+b2)
        public override double Area()
        {
            int height = (x1y2.GetY() - x1y1.GetY());
            int b1 = (x2y1.GetX() - x1y1.GetX());
            int b2 = (x2y2.GetX() - x1y2.GetX());
            return 0.5 * height * (b1 + b2);
        }

    }

    //Point Class with private x & y with an overridden ToString() method
    public class PClass
    {
        private int x;
        private int y;
        public PClass(int x1, int y1)
        {
            x = x1;
            y = y1;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public override string ToString()
        {
            return "(" + x.ToString() + " , " + y.ToString() + ")";
        }
    }
}
