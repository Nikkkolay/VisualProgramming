using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace Lab8
{
    public partial class Item : UserControl
    {
        public Item(XElement item)
        {
            InitializeComponent();

            var date = item.Element("pubDate");
            var titleText = item.Element("title");
            var titleUri = item.Element("link");
            var description = item.Element("description");

            ShowDate(date.Value);
            ShowTitle(titleText.Value, titleUri.Value);
            if(description != null)
            {
                Description.Text = description.Value;
            }
        }

        private void ShowDate(string dateString)
        {
            string parseFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";
            DateTime date = DateTime.ParseExact(dateString, parseFormat, CultureInfo.InvariantCulture);
            Date.Content = date;
        }

        private void ShowTitle(string title, string uri)
        {
            Hyperlink hyperLink = new Hyperlink()
            {
                NavigateUri = new Uri(uri)
            };
            hyperLink.RequestNavigate += HyperlinkRequestNavigate;
            hyperLink.Inlines.Add(title);
            Title.Inlines.Add(hyperLink);
        }

        private void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
