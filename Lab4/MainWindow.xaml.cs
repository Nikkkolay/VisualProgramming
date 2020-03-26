using System;
using System.Windows;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GenericsDescSortedList<int> _list;
        public MainWindow()
        {
            InitializeComponent();
            _list = new GenericsDescSortedList<int>();
        }

        private void AddNumberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _list.Add(Convert.ToInt32(BoxWithNewNumber.Text));
                BoxWithNewNumber.Text = "";
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void UpdateListInfo_Click(object sender, RoutedEventArgs e)
        {
            NumbersList.Text = "";
            for(int i = 0; i < _list.Count; i++)
            {
                NumbersList.Text += $"{_list[i]} ";
            }

            Count.Text = _list.Count.ToString();


            Min.Text = _list.Count > 0 ?_list.Min().ToString(): "?";
            Max.Text = _list.Count > 0 ?_list.Max().ToString(): "?";
        }
    }
}
