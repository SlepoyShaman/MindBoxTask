using AreaLib.Figures;
using System.Xml.Serialization;

namespace AreaLib.Test.Figures
{
    public class TriangleTest
    {
        [Fact]
        public void IsTriangle_Uncorrect()
        {
            const int testsCount = 3;
            var sitesA = new double[testsCount] { 1, 0, 15};
            var sitesB = new double[testsCount] { -2, 5, 4 };
            var sitesC = new double[testsCount] { 1, 5, 5 };

            for(int i = 0; i < testsCount; i++)
            {
                double siteA = sitesA[i];
                double siteB = sitesB[i];
                double siteC = sitesC[i];

                Assert.Throws<ArgumentException>(() => { Triangle triangle = new Triangle(siteA, siteB, siteC); });
                Assert.Throws<ArgumentException>(() => { Figure figureTriangle = new Triangle(siteA, siteB, siteC); });
            }
        }

        [Fact]
        public void IsRight()
        {
            var rightTriangle = new Triangle(161, 240, 289);
            var notRightTriangle = new Triangle(12, 8, 7);

            bool rightResult = rightTriangle.IsRight();
            bool notRightResult = notRightTriangle.IsRight();

            Assert.True(rightResult);
            Assert.False(notRightResult);
        }

        [Fact]
        public void GetArea()
        {
            double siteA = 3;
            double siteB = 4;
            double siteC = 5;

            double halfPerimeter = (siteA + siteB + siteC) / 2;
            var expected = Math.Sqrt(halfPerimeter * (halfPerimeter - siteA) * (halfPerimeter - siteB) * (halfPerimeter - siteC));

            Triangle triangle = new Triangle(siteA, siteB, siteC);
            Figure figureTriangle = new Triangle(siteA, siteB, siteC);

            var triangleResult = triangle.Area;
            var figureResult = figureTriangle.Area;

            Assert.Equal(expected, triangleResult);
            Assert.Equal(expected, figureResult);
        }

    }
}
