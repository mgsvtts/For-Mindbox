using FigureClassLibrary.Interfaces;

namespace FigureClassLibrary.Figures
{
    public class Triangle : IFigure
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Triangle(double a, double b, double c)
        {
            if (!SidesValidated(a, b, c))
                throw new ArgumentException("Треульник не существует если одна из его сторон больше или равна сумме двух других");

            A = a; B = b; C = c;
        }

        public Triangle(double a, double b, double angle, bool useAngle)
        {
            double c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angle));

            if (!useAngle) throw new ArgumentException("Подтвердите, что хотите использовать данную перегрузку, передав true в качестве параметра useAngle");

            if (!SidesValidated(a, b, c))
                throw new ArgumentException("Треульник не существует если одна из его сторон больше или равна сумме двух других");

            A = a; B = b; C = c;
        }

        public double GetArea()
        {
            double p = (A + B + C) / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public bool IsRight()
        {
            return A * A == B * B + C * C || B * B == A * A + C * C || C * C == A * A + B * B;
        }

        private static bool SidesValidated(double a, double b, double c)
        {
            if (a >= b + c)
                return false;
            else if (b >= a + c)
                return false;
            else if (c >= a + b)
                return false;

            return true;
        }
    }
}