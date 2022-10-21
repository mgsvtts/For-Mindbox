using FigureClassLibrary.Interfaces;

namespace FigureClassLibrary.Extensions
{
    public static class FigureExtensions
    {
        public static double GetRoundedArea(this IFigure figure, int round = 0) => Math.Round(figure.GetArea(), round);
    }
}