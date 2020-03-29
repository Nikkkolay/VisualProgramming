using System.Windows;
using System.Windows.Controls;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var element = new YControlPanel();
            element.YPositionChanged += OnYPositionChanged;
            MainGrid.Children.Add(element);
            Grid.SetColumn(element, 0);
        }

        public void OnYPositionChanged(double y)
        {
            Label.Content = y;
        }
    }
}
