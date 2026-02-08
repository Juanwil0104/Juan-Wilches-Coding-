namespace CSCI106.Tests
{
    public class TheSvgBuilder
    {
       //Test for basic rectangle
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
    }
}
