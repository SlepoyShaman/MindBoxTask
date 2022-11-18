using AreaLib.Figures;

namespace AreaLib.Test.Figures
{
    public class CircleTest
    {
        [Fact]
        public void CreateCircle_Uncorrect()
        {
            double radius = -1;

            Assert.Throws<ArgumentException>(() => { Figure figureCircle = new Circle(radius); });
            Assert.Throws<ArgumentException>(() => { Circle circle = new Circle(radius); });
        }

        [Fact]
        public void GetArea()
        {
            double radius = 2.1;
            double expected = Math.PI * radius * radius;

            Circle circle = new Circle(radius);
            Figure figureCircle = new Circle(radius);

            Assert.Equal(expected, circle.Area);
            Assert.Equal(expected, figureCircle.Area);
        }
    }
}
