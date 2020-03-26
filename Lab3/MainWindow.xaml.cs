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

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BallCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ball = new Ball(Convert.ToDouble(Radius.Text));
                BallArea.Text = ball.CalcArea().ToString();
                BallVolume.Text = ball.CalcVolume().ToString();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ParallelepipedCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var parallelepiped = new Parallelepiped(Convert.ToDouble(SideA.Text), Convert.ToDouble(SideB.Text), Convert.ToDouble(SideC.Text));
                ParallelepipedArea.Text = parallelepiped.CalcArea().ToString();
                ParallelepipedVolume.Text = parallelepiped.CalcVolume().ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
