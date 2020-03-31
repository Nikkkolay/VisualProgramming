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

namespace Lab7
{
    public partial class Matrix : UserControl
    {
        public Matrix()
        {
            InitializeComponent();
        }

        public void ShowMatrix(Matrix3X3 matrix)
        {
            Item1.Text = Math.Round(matrix[0, 0], 2).ToString();
            Item2.Text = Math.Round(matrix[0, 1], 2).ToString();
            Item3.Text = Math.Round(matrix[0, 2], 2).ToString();
            Item4.Text = Math.Round(matrix[1, 0], 2).ToString();
            Item5.Text = Math.Round(matrix[1, 1], 2).ToString();
            Item6.Text = Math.Round(matrix[1, 2], 2).ToString();
            Item7.Text = Math.Round(matrix[2, 0], 2).ToString();
            Item8.Text = Math.Round(matrix[2, 1], 2).ToString();
            Item9.Text = Math.Round(matrix[2, 2], 2).ToString();
        }
    }
}
