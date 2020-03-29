using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Логика взаимодействия для Legend.xaml
    /// </summary>
    public partial class Legend : UserControl
    {
        public Legend(Color color, string description)
        {
            InitializeComponent();

            Rectangle.Fill = new SolidColorBrush(color);
            Label.Content = description;
        }
    }
}
