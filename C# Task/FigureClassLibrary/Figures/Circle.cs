using FigureClassLibrary.Interfaces;

namespace FigureClassLibrary.Figures
{
    public class Circle : IFigure
    {
        private double _radius;

        public double Radius
        {
            get { return _radius; }

            private set
            {
                if (value <= 0) throw new ArgumentException("Радиус не может быть меньше или равен 0");

                _radius = value;
            }
        }

        public Circle(double radius) => Radius = radius;

        public double GetArea() => Radius * Radius * Math.PI;
    }
}