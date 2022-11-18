namespace AreaLib.Figures
{
    public class Triangle : Figure
    {
        private readonly double _sizeA;
        private readonly double _sizeB;
        private readonly double _sizeC;

        public Triangle(double sizeA, double sizeB, double sizeC)
        {
            IsTriangle(sizeA, sizeB, sizeC);
            _sizeA = sizeA;
            _sizeB = sizeB;
            _sizeC = sizeC;
        }

        public bool IsRight()
        {
            double hypotenuse = Math.Max(_sizeA, Math.Max(_sizeB, _sizeC));
            return (2 * hypotenuse * hypotenuse == _sizeA * _sizeA + _sizeB * _sizeB + _sizeC * _sizeC);
        }
        private void IsTriangle(double A, double B, double C)
        {
            if (A <= 0 || B <= 0 || C <= 0)
                throw new ArgumentException("Sides must be more than 0");

            if (!(A + B > C && A + C > B && B + C > A))
                throw new ArgumentException("It's not a triangle");
        }
        protected override double CalculateArea()
        {
            double halfPerimeter = (_sizeA + _sizeB + _sizeC) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - _sizeA) * (halfPerimeter - _sizeB) * (halfPerimeter - _sizeC));
        }
    }
}
