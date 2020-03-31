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
/*
Реализовать несколько запросов LINQ к этому списку, 
используя операции фильтрации, сортировки и группировки. 
*/
namespace Lab7
{
    public partial class MainWindow : Window
    {
        private Random _random;
        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
            CalcExemples();
        }

        private void CalcExemples()
        {
            var matrixs = new List<Matrix3X3>();
            for (int i = 0; i < 100; i++)
            {
                matrixs.Add(GetRandomMatrix());
            }

            CalcExemple1(matrixs);
            CalcExemple2(matrixs);
            CalcExemple3(matrixs);
            CalcExemple4(matrixs);
        }

        private void CalcExemple1(List<Matrix3X3> matrixs)
        {
            var results = from matrix in matrixs
                    where matrix.Determinant() < 0
                    orderby matrix.SumOfElementsOnMainDiagonal()
                    select matrix;

            foreach(var result in results)
            {
                var matrix = new Matrix();
                matrix.Margin = new Thickness(5);
                Exemple1.Children.Add(matrix);
                matrix.ShowMatrix(result);
            }
        }

        private void CalcExemple2(List<Matrix3X3> matrixs)
        {
            var results = from matrix in matrixs
                          where Math.Abs(matrix.SumOfElementsOnMainDiagonal() - matrix.SumOfElementsOnSideDiagonal()) < 1
                          orderby Math.Abs(matrix.SumOfElementsOnMainDiagonal() - matrix.SumOfElementsOnSideDiagonal()) descending
                          select matrix;

            foreach (var result in results)
            {
                var matrix = new Matrix();
                matrix.Margin = new Thickness(5);
                Exemple2.Children.Add(matrix);
                matrix.ShowMatrix(result);
            }
        }

        private void CalcExemple3(List<Matrix3X3> matrixs)
        {
            var results = from matrix in matrixs
                          orderby matrix.SumOfElementsOnMainDiagonal()
                          group matrix by matrix.SumOfElementsOnMainDiagonal();

            foreach (var result in results)
            {
                var label = new Label()
                {
                    Content = $"{result.Key}:"
                };
                Exemple3.Children.Add(label);

                foreach(var matrix in result)
                {
                    var matrixView = new Matrix();
                    matrixView.Margin = new Thickness(5);
                    Exemple3.Children.Add(matrixView);
                    matrixView.ShowMatrix(matrix);
                }
            }
        }

        private void CalcExemple4(List<Matrix3X3> matrixs)
        {
            var results = from matrix in matrixs
                          orderby matrix.Determinant() descending
                          select matrix;

            foreach (var result in results)
            {
                var matrix = new Matrix();
                matrix.Margin = new Thickness(5);
                Exemple4.Children.Add(matrix);
                matrix.ShowMatrix(result);
            }
        }

        private Matrix3X3 GetRandomMatrix()
        {
            var values = new double[3, 3];
            
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    values[i, j] = Math.Round((_random.NextDouble() - 0.5) * 10, 2);
                }
            }

            return new Matrix3X3(values);
        }
    }
}
