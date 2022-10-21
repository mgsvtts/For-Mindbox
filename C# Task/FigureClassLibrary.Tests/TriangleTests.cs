using FigureClassLibrary.Extensions;
using FigureClassLibrary.Figures;

namespace FigureClassLibrary.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void Can_Be_Created_With_3_Sides()
        {
            var triangle = new Triangle(2, 3, 4);

            Assert.IsType<Triangle>(triangle);
            Assert.Equal(2, triangle.A);
            Assert.Equal(3, triangle.B);
            Assert.Equal(4, triangle.C);
            Assert.Equal(2.9, triangle.GetRoundedArea(1));
        }

        [Fact]
        public void Can_Be_Created_With_2_Sides_And_Angle()
        {
            var triangle = new Triangle(2, 3, 4, true);

            Assert.IsType<Triangle>(triangle);
            Assert.Equal(2, triangle.A);
            Assert.Equal(3, triangle.B);
            Assert.Equal(4.6, Math.Round(triangle.C, 1));
        }

        [Fact]
        public void Area_Calculates_Correctly()
        {
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(3, 4, 90, true);

            Assert.Equal(6, triangle1.GetArea());
            Assert.Equal(triangle1.GetArea(), Math.Ceiling(triangle2.GetArea()));
        }

        [Fact]
        public void Can_Be_Right()
        {
            var rightTriangle = new Triangle(3,4,5);
            var notRightTriangle = new Triangle(2, 3, 4);

            Assert.True(rightTriangle.IsRight());
            Assert.False(notRightTriangle.IsRight());
        }

        [Fact]
        public void Throws_ArgumentException_Without_Overload_Confirmation()
        {
            var function = () => new Triangle(2, 3, 4, false);

            Assert.Throws<ArgumentException>(function);
        }

        [Fact]
        public void Throws_ArgumentException_With_Invalid_Params()
        {
            var function = () => new Triangle(-1, -1, -1);

            Assert.Throws<ArgumentException>(function);
        }
    }
}