using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class Figure
    {
        public abstract double GetSquare();
    }

    public class Circle : Figure
    {
        public Point center {  get; set; }
        public double radius { get; set; }
        public Circle( Point center, double radius) 
        {
            this.center = center;
            this.radius = radius; 
        }
        
        public override double GetSquare()
        {
            return Math.PI*radius*radius;
        }
    }

    public class Triangle : Figure
    {
        public Point angle1 { get; set; }
        public Point angle2 { get; set; }
        public Point angle3 { get; set; }
        public Triangle (Point angle1, Point angle2, Point angle3)
        {
            this.angle1 = angle1;
            this.angle2 = angle2;
            this.angle3 = angle3;
        }

        public double GetSideLength(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        public double  GetPerimetr()
        {
            return  GetSideLength(angle1, angle3) +
                    GetSideLength(angle2, angle1) +
                    GetSideLength(angle3, angle2);
        }
        public override double GetSquare()
        {
            double semiperimetr = GetPerimetr() / 2;
            return Math.Sqrt(semiperimetr * (semiperimetr - GetSideLength(angle1, angle3)) *
                                            (semiperimetr - GetSideLength(angle2, angle1)) *
                                            (semiperimetr - GetSideLength(angle3, angle2)));
        }

        public bool IsRight()
        {
            return  (Math.Pow(GetSideLength(angle1, angle3), 2) + Math.Pow(GetSideLength(angle2, angle1), 2) == Math.Pow(GetSideLength(angle3, angle2), 2)) ||
                    (Math.Pow(GetSideLength(angle2, angle1), 2) + Math.Pow(GetSideLength(angle3, angle2), 2) == Math.Pow(GetSideLength(angle1, angle3), 2)) ||
                    (Math.Pow(GetSideLength(angle3, angle2), 2) + Math.Pow(GetSideLength(angle1, angle3), 2) == Math.Pow(GetSideLength(angle2, angle1), 2));
        }
    }
}

