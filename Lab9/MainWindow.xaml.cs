using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Matrix _matrixLeft;
        private Matrix _matrixRight;

        private int _height = 6;
        private int _width = 6;

        public MainWindow()
        {
            InitializeComponent();

            _matrixLeft = new Matrix(_height, _width, false);
            _matrixLeft.Fill(GetRandomMatrix(_height, _width));
            _grid.Children.Add(_matrixLeft);

            _matrixRight = new Matrix(_height, _width, true);
            _grid.Children.Add(_matrixRight);
            Grid.SetColumn(_matrixRight, 1);


        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            var numThreads = Convert.ToInt32(numThreadBox.Text);

            var subMatrix = MatrixHelper.FindMaxSubmatrix(_matrixLeft.GetValues(), _height, _width, numThreads);

            for(int i = 0; i < _height; i++)
                for(int j = 0; j < _width; j++)
                    _matrixRight[i, j] = "";

            for (int i = subMatrix.TopPosition; i < subMatrix.TopPosition + subMatrix.Height; i++)
                for (int j = subMatrix.LeftPosition; j < subMatrix.LeftPosition + subMatrix.Width; j++)
                    _matrixRight[i, j] = _matrixLeft[i, j];
        }

        private int[,] GetRandomMatrix(int height, int width)
        {
            var values = new int[height, width];
            var random = new Random();

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    values[i, j] = random.Next(-10, 10);

            return values;
        }
    }
}
