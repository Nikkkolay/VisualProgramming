using Lab2.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace lab2_view
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var leftMatrix = new Matrix3X3(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            WriteMatrix(DataGrid1, leftMatrix);
            var rightMatrix = new Matrix3X3(new double[,] { { 7, 2, 3 }, { 4, 0, 4 }, { -7, 8, 9 } });
            WriteMatrix(DataGrid2, rightMatrix);

            var matrixSum = leftMatrix + rightMatrix;
            WriteMatrix(DataGrid3, matrixSum);

            var matrixSub = leftMatrix - rightMatrix;
            WriteMatrix(DataGrid4, matrixSub);

            Determinant.Text = leftMatrix.Determinant().ToString();
            SumOnMainDiagonal.Text = leftMatrix.SumOfElementsOnMainDiagonal().ToString();
            SumOnSideDiagonal.Text = leftMatrix.SumOfElementsOnSideDiagonal().ToString();
        }

        private void WriteMatrix(DataGrid view, Matrix3X3 matrix)
        {
            var data = ConvertMatrixToListArray(matrix);
            view.ItemsSource = data;

            
            for (int i = 0; i < 3; i++)
            {
                var column = new DataGridTextColumn();
                column.Binding = new Binding(string.Format("[{0}]", i));
                view.Columns.Add(column);
            }
                
        }

        private List<double[]> ConvertMatrixToListArray(Matrix3X3 matrix)
        {
            var data = new List<double[]>();
            for (int i = 0; i < 3; i++)
            {
                var row = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    row[j] = matrix[i, j];
                }
                data.Add(row);
            }
            return data;
        }
    }
}
