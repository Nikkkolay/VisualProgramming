using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab9
{
    public partial class Matrix : UserControl
    {
        private TextBox[,] _values;
        private int _height;
        private int _width;

        public Matrix(int height, int width, bool isReadOnly)
        {
            InitializeComponent();
            _height = height;
            _width = width;
            _values = new TextBox[height, width];

            for (int i = 0; i < height; i++)
                _grid.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < width; i++)
                _grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    _values[i, j] = new TextBox { TextAlignment = TextAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, Margin = new Thickness(2), IsReadOnly = isReadOnly, FontSize = 15};
                    _grid.Children.Add(_values[i, j]);
                    Grid.SetRow(_values[i, j], i);
                    Grid.SetColumn(_values[i, j], j);
                }
        }

        public string this[int i, int j]
        {
            get
            {
                return _values[i, j].Text;
            }

            set
            {
                _values[i, j].Text = value;
            }
        }

        public void Fill(int[,] matrix)
        {
            for (int i = 0; i < _height; i++)
                for (int j = 0; j < _width; j++)
                    _values[i, j].Text = matrix[i, j].ToString();
        }

        public int[,] GetValues()
        {
            var answer = new int[_height, _width];

            for (int i = 0; i < _height; i++)
                for (int j = 0; j < _width; j++)
                    answer[i, j] = Convert.ToInt32(_values[i, j].Text);

            return answer;
        }
    }
}
