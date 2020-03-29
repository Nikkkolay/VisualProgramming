using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab6
{
    public partial class MainWindow : Window
    {
        private readonly List<PieChartSegment> religiousStatistics = new List<PieChartSegment>
        {
            new PieChartSegment(Colors.Tomato, 33, "Христиане"),
            new PieChartSegment(Colors.SeaGreen, 22, "Мусульмане"),
            new PieChartSegment(Colors.Violet, 14, "Индуисты"),
            new PieChartSegment(Colors.SandyBrown, 7, "Буддисты"),
            new PieChartSegment(Colors.Silver, 24, "Остальные"),
        };

        public MainWindow()
        {
            InitializeComponent();

            var pieChart = new PieChart(religiousStatistics, 10);

            Grid.Children.Add(pieChart);
            Grid.SetColumn(pieChart, 1);
        }
    }
}
