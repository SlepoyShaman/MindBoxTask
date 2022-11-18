namespace AreaLib
{
    public abstract class Figure
    {
        private readonly Lazy<double> _area;  
        public double Area { get => _area.Value; }

        protected Figure()
        {
            _area = new Lazy<double>(CalculateArea);
        }

        protected abstract double CalculateArea();

    }
}
