using AreaLib.Supporting;

namespace AreaLib.Test
{
    public class UnknownFigureTest
    {
        [Fact]
        public void FindArea_UncorrectParams()
        {
            var points = new Point[] { new Point(1, 2), new Point(2, 1) };
            var pairs = new (double, double)[] { (1, 2) , (2, 1) };

            Assert.Throws<Exception>(() => UnknownFigure.FindArea(points));
            Assert.Throws<Exception>(() => UnknownFigure.FindArea(pairs));
        }

        [Fact]
        public void FindArea_CorrectParams()
        {
            var trianglePoints = new Point[] {  new Point(1, 1), new Point(2,4), new Point(5,3) };
            var pentagonPairs = new (double, double)[] { (-2, -1), (-1, 1), (1, 2), (3, 1), (2, -2) };

            double triangleResult = UnknownFigure.FindArea(trianglePoints);
            double pentagonResult = UnknownFigure.FindArea(pentagonPairs);

            Assert.Equal( 5, triangleResult);
            Assert.Equal( 12.5, pentagonResult);
        }

        [Fact]
        public void FindArea_IdenticalParams()
        {
            var IdenticalPoints = new Point[] { new Point(1, 1), new Point(1, 1), new Point(1, 1) };
            var IdenticalPairs = new (double, double)[] { (-2, -1), (-2, -1), (-2, -1) };

            double IdenticalPointsResult = UnknownFigure.FindArea(IdenticalPoints);
            double IdenticalPairsResult = UnknownFigure.FindArea(IdenticalPairs);

            Assert.Equal( 0, IdenticalPointsResult);
            Assert.Equal(0, IdenticalPairsResult);
        }


    }
}