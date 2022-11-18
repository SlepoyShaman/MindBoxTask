using AreaLib.Supporting;

namespace AreaLib.Figures
{
    public class TriangleByCoords : Figure
    {
        private readonly Point vectorAB;
        private readonly Point vectorAC;
        private readonly Point vectorBC;

        public TriangleByCoords(Point a, Point b, Point c)
        {
            vectorAB = a.GetVectorCords(b);
            vectorAC = a.GetVectorCords(c);
            vectorBC = b.GetVectorCords(c);

            IsTriangle();
        }

        public TriangleByCoords((double, double) a, (double, double) b, (double, double) c)
        {
            vectorAB = new Point(a.Item1, a.Item2).GetVectorCords(new Point(b.Item1, b.Item2));
            vectorAC = new Point(a.Item1, a.Item2).GetVectorCords(new Point(c.Item1, c.Item2));
            vectorBC = new Point(b.Item1, b.Item2).GetVectorCords(new Point(c.Item1, c.Item2));

            IsTriangle();
        }

        private void IsTriangle()
        {
            if (Point.VectorProductModule(vectorAB, vectorAC) == 0)
                throw new ArgumentException("It's not a triangle");
        }

        public bool IsRight()
        {
            if (Point.ScalarProduct(vectorAC, vectorBC) == 0
                || Point.ScalarProduct(vectorAC, vectorAB) == 0
                || Point.ScalarProduct(vectorAB, vectorBC) == 0)
                return true;
            return false;
        }
        protected override double CalculateArea()
            => Point.VectorProductModule(vectorAB, vectorAC) / 2;
        
    }
}
