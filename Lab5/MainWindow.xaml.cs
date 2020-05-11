using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        private int _counterZ;
        private int _counterF;
        
        public MainWindow()
        {
            InitializeComponent();

            var element = new ZControlPanel();
            element.ZDrawn += OnZDrawn;
            MainGrid.Children.Add(element);
            Grid.SetColumn(element, 0);

            _label.Content = _counterZ;
            _labelF.Content = _counterF;
        }

        public void OnZDrawn()
        {
            _counterZ++;
            _label.Content = _counterZ;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            _counterF++;
            _labelF.Content = _counterF;
        }
    }
}
