using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml;


namespace ChronoGGDesktopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string SteamUrl;

        public MainWindow()
        {
            InitializeComponent();

            SupportorCombo.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;


            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load("https://community.chrono.gg/c/daily-deals.rss");

            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
            StringBuilder rssContent = new StringBuilder();


            string title = "";
            string description = "";

            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                 title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssContent.Append("<a href='" + link + "'>" + title + "</a><br>" + description);
                break;
            }


            string gameUrl = "";
            string steamLink = "";

            var linkParser = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match m in linkParser.Matches(description))
            {
                if(m.Value.EndsWith(".jpg"))
                    gameUrl = m.Value;

                if (m.Value.StartsWith("http://store.steampowered"))
                    steamLink = m.Value;

                if (gameUrl != "" && steamLink != "")
                    break;
            }

            SteamUrl = steamLink;

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(gameUrl);
            logo.EndInit();

            TitleLable.Content = title + title + title;
            GameImage.Source = logo;
            

        }


        private void CloseX_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void GameImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void SteamButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(SteamUrl);
        }
    }
}
