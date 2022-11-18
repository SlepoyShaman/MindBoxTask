using AreaLib.Figures;
using AreaLib.Supporting;

namespace AreaLib.Test.Figures
{
    public class TriangleByCoordsTest
    {
        [Fact]
        public void CreateTriangleByCoords_Uncorrect()
        {
            var pointA = new Point(1, 0);
            var pointB = new Point(3, 0);
            var pointC = new Point(2, 0);

            (double, double) pairA = (1.5, 0);
            (double, double) pairB = (1.5, 0);
            (double, double) pairC = (3, 2.5);

            Assert.Throws<ArgumentException>(() => { Figure figureTriangle = new TriangleByCoords(pointA, pointB, pointC); });
            Assert.Throws<ArgumentException>(() => { TriangleByCoords figureTriangle = new TriangleByCoords(pairA, pairB, pairC); });
        }

        [Fact]
        public void IsRight()
        {
            var rightTriangle = new TriangleByCoords(new Point(0, 5), new Point(0, 0), new Point(5, 0));
            var notRightTriangle = new TriangleByCoords((1, 2), (2, 4), (3, 3));

            bool rightResult = rightTriangle.IsRight();
            bool notRightResult = notRightTriangle.IsRight();

            Assert.True(rightResult);
            Assert.False(notRightResult);
        }

        [Fact]
        public void GetArea()
        {
            Point pointA = new(0,5);
            Point pointB = new(0, 0);
            Point pointC = new(5, 0);

            var vectorAB = pointA.GetVectorCords(pointB);
            var vectorAC = pointA.GetVectorCords(pointC);
            var expected = Point.VectorProductModule(vectorAB, vectorAC) / 2;

            var triangle = new TriangleByCoords(pointA, pointB, pointC);
            var result = triangle.Area;

            Assert.Equal(expected, result);
        }
    }
}
