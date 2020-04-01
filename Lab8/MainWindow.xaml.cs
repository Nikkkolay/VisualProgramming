using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Xml.Linq;

namespace Lab8
{
    public partial class MainWindow : Window
    {
        private XElement _data;
        BackgroundWorker _backgroundWorker;
        private string _lastUpdateData = "";
        private bool _isLoading;

        public MainWindow()
        {
            InitializeComponent();

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += LoadData;
            _backgroundWorker.RunWorkerCompleted += OnRunWorkerCompleted;

            TryUpdateData();
        }

        private void TryUpdateData()
        {
            if (_isLoading) return;

            _isLoading = true;
            _backgroundWorker.RunWorkerAsync("http://www.consultant.ru/rss/hotdocs.xml");
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            TryUpdateData();
        }

        private void LoadData(object sender, DoWorkEventArgs e)
        {
            _data = XElement.Load(e.Argument.ToString());

            e.Result = _data.Element("channel").Element("lastBuildDate").Value;
        }

        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isLoading = false;
            var updateTime = (string)e.Result;

            if (_lastUpdateData == "")
            {
                _lastUpdateData = updateTime;
                ParsData();
                return;
            }
            if(_lastUpdateData != updateTime)
            {
                _lastUpdateData = updateTime;
                ParsData();
                MessageBox.Show("Данные обновленны!");
            }
            else
            {
                MessageBox.Show("Обновлений не было.");
            }
        }

        private void ParsData()
        {
            XElement channel = _data.Element("channel");

            NewsTitle.Content = channel.Element("title").Value;

            Description.Content = channel.Element("description").Value;

            string parseFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";
            DateTime date = DateTime.ParseExact(channel.Element("lastBuildDate").Value, parseFormat, CultureInfo.InvariantCulture);
            Date.Content = date;

            foreach (var element in channel.Elements("item"))
            {
                var item = new Item(element);
                item.Margin = new Thickness(5);
                PlaseForItems.Children.Add(item);
            }
        }
    }
}
