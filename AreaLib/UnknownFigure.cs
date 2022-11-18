using AreaLib.Supporting;

namespace AreaLib
{
    public static class UnknownFigure
    {
        public static double FindArea(params Point[] points) // use the shoelace algorithm (Gauss's area formula) 
        {
            if (points.Length < 3)
                throw new Exception("Figure cannot contain less than 3 points");

            double sum = 0;
            int count = 0;
            foreach (var point in points)
            {
                sum += point.Y;
                count++;
            }

            double middle = sum / count;

            var UpperPoints = points.Where(p => p.Y > middle).OrderBy(p => -1 * p.X);
            var DownPoints = points.Where(p => p.Y <= middle).OrderBy(p => p.X);

            var AllPoints = DownPoints.Union(UpperPoints).ToArray();

            double doubleArea = 0;
            int module = AllPoints.Length;
            for (int i = 0; i < module; i++)
                doubleArea += AllPoints[i].X * AllPoints[(i + 1) % module].Y - AllPoints[(i + 1) % module].X * AllPoints[i].Y;
            
            return doubleArea / 2;
        }

        public static double FindArea(params (double, double)[] pairs)
        {
            var points = pairs.Select(p => new Point(p.Item1, p.Item2)).ToArray();
            return FindArea(points);
        }
    }
}
