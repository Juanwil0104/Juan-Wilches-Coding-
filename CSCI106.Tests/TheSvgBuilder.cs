using NUnit.Framework;
using System;

namespace CSCI106.Tests
{
    public class TheSvgBuilder
    {
        // Test for basic rectangle
        [Test]
        public void AddsBasicRectangleToSvg()
        {
            var svgBuilder = SvgBuilder.New((100, 100));
            svgBuilder.AddRect(10, 10, 30, 40, "red");
            var svg = svgBuilder.Build();

            Assert.That(svg, Contains.Substring("<rect x=\"10\" y=\"10\" width=\"30\" height=\"40\" fill=\"red\" />"));
        }

        // Test for rounded rectangle
        [Test]
        public void AddsRoundedRectangleToSvg()
        {
            var svgBuilder = SvgBuilder.New((100, 100));
            svgBuilder.AddRoundedRect(10, 10, 30, 40, 5, 5, "blue");
            var svg = svgBuilder.Build();

            Assert.That(svg, Contains.Substring("<rect x=\"10\" y=\"10\" width=\"30\" height=\"40\" rx=\"5\" ry=\"5\" fill=\"blue\" />"));
        }

        // Test that partially visible rectangles are allowed
        [Test]
        public void AllowsPartiallyVisibleRectangle()
        {
            var svgBuilder = SvgBuilder.New((100, 100));

            svgBuilder.AddRect(90, 90, 20, 20, "green");

            var svg = svgBuilder.Build();

            Assert.That(svg, Contains.Substring("<rect x=\"90\" y=\"90\" width=\"20\" height=\"20\" fill=\"green\" />"));
        }

        // Test zero width throws exception
        [Test]
        public void ThrowsWhenWidthIsZero()
        {
            var svgBuilder = SvgBuilder.New((100, 100));

            Assert.Throws<ArgumentException>(() =>
                svgBuilder.AddRect(10, 10, 0, 20, "red"));
        }

        // Test zero height throws exception
        [Test]
        public void ThrowsWhenHeightIsZero()
        {
            var svgBuilder = SvgBuilder.New((100, 100));

            Assert.Throws<ArgumentException>(() =>
                svgBuilder.AddRect(10, 10, 20, 0, "red"));
        }

        // Test rectangle completely outside to the right throws
        [Test]
        public void ThrowsWhenRectangleIsCompletelyOutsideRight()
        {
            var svgBuilder = SvgBuilder.New((100, 100));

            Assert.Throws<ArgumentException>(() =>
                svgBuilder.AddRect(150, 10, 20, 20, "red"));
        }

        // Test rectangle completely outside below throws
        [Test]
        public void ThrowsWhenRectangleIsCompletelyOutsideBottom()
        {
            var svgBuilder = SvgBuilder.New((100, 100));

            Assert.Throws<ArgumentException>(() =>
                svgBuilder.AddRect(10, 150, 20, 20, "red"));
        }

        // Test rounded rectangle also validates input
        [Test]
        public void RoundedRectangleThrowsWhenInvalid()
        {
            var svgBuilder = SvgBuilder.New((100, 100));

            Assert.Throws<ArgumentException>(() =>
                svgBuilder.AddRoundedRect(200, 200, 10, 10, 5, 5, "blue"));
        }
    }
}
