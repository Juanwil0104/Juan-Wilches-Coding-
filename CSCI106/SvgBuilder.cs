namespace CSCI106
{
    public class SvgBuilder
    {
        private const string SVG_HEADER_TEMPLATE = "<svg width=\"{0}\" height=\"{1}\" xmlns=\"http://www.w3.org/2000/svg\">";
        private const string SVG_FOOTER = "</svg>";

        private string Buffer;
        private uint Width;
        private uint Height;

        public static SvgBuilder New((uint, uint) dimensions)
        {
            var (width, height) = dimensions;

            return new()
            {
                Buffer = string.Empty,
                Width = width,
                Height = height,
            };
        }

        // Rectangle validation method
        private bool IsValidRect(uint x, uint y, uint width, uint height)
        {
            // Must have non-zero dimensions
            if (width == 0 || height == 0)
                return false;

            // Completely outside to the right
            if (x >= Width)
                return false;

            // Completely outside below
            if (y >= Height)
                return false;

            return true;
        }

        // Basic rectangle
        public void AddRect(uint x, uint y, uint width, uint height, string fill)
        {
            if (!IsValidRect(x, y, width, height))
            {
                throw new ArgumentException("Invalid rectangle dimensions.");
            }

            Buffer += $"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" fill=\"{fill}\" />";
        }

        // Rounded rectangle
        public void AddRoundedRect(uint x, uint y, uint width, uint height, uint rx, uint ry, string fill)
        {
            if (!IsValidRect(x, y, width, height))
            {
                throw new ArgumentException("Invalid rectangle dimensions.");
            }

            Buffer += $"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" rx=\"{rx}\" ry=\"{ry}\" fill=\"{fill}\" />";
        }

        public string Build() =>
            string.Format(SVG_HEADER_TEMPLATE, Width, Height)
                + Buffer
                + SVG_FOOTER;
    }
}
