using FigureClassLibrary.Figures;

namespace FigureClassLibrary.Tests
{
    public class CircleTests
    {
        [Fact]
        public void Can_Be_Created()
        {
            var circle = new Circle(5);

            Assert.IsType<Circle>(circle);
            Assert.Equal(5, circle.Radius);
        }

        [Fact]
        public void Throws_ArgumentException_With_Invalid_Params()
        {
            var function = () => new Circle(-100);

            Assert.Throws<ArgumentException>(function);
        }

        [Fact]
        public void Area_Calculates_Correctly()
        {
            var circle = new Circle(5);

            Assert.Equal(25 * Math.PI, circle.GetArea());
        }
    }
}