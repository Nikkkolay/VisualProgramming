using System.Windows.Media;

namespace Lab6
{
    public class PieChartSegment
    {
        public Color Color { get; set; }
        public int Percent { get; set; }
        public string Description { get; set; }

        public PieChartSegment(Color color, int percent, string description)
        {
            Color = color;
            Percent = percent;
            Description = description;
        }
    }
}