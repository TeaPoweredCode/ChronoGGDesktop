using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;


namespace ChronoGGDesktopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        string SteamUrl;

        public MainWindow()
        {
            InitializeComponent();           
            this.ShowActivated = false;
            this.Width = 220;

            LoadSettings();

            GetRSSData();                       
            StartDailyTimer();
        }

        private void StartDailyTimer()
        {       
            DateTime utcNow = DateTime.UtcNow;
            DateTime NewGameTime = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day).AddHours(17);

            if (utcNow.Hour >= 17)
                NewGameTime = NewGameTime.AddDays(1);

            TimeSpan duration = NewGameTime - utcNow;

            int ensureChangeDelay = 5;
            int targetMinutes = (int)Math.Ceiling(duration.TotalMinutes) + ensureChangeDelay;
            dispatcherTimer.Interval = new TimeSpan(0, targetMinutes , 0);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GetRSSData();
            dispatcherTimer.Interval = new TimeSpan(24, 0, 0);

            if(Properties.Settings.Default.ShowOnNewGame)
                this.Show();            
        }

        private void GetRSSData()
        {
            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load("https://community.chrono.gg/c/daily-deals.rss");
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            string title = GetNoteAttribute(rssNodes[0], "title");
            string description = GetNoteAttribute(rssNodes[0], "description");
            //string link = GetNoteAttribute(rssNodes[0], "link");

            string gameUrl, steamLink;
            GetDescriptionUrls(description, out gameUrl, out steamLink);

            BitmapImage logo = new BitmapImage(new Uri(gameUrl));
            SteamUrl = steamLink;

            TitleTextBox.Text = title;
            GameImage.Source = logo;
        }

        private static void GetDescriptionUrls(string description, out string gameUrl, out string steamLink)
        {
            gameUrl = "";
            steamLink = "";

            var linkParser = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match m in linkParser.Matches(description))
            {
                if (m.Value.EndsWith(".jpg"))
                    gameUrl = m.Value;

                if (m.Value.StartsWith("http://store.steampowered"))
                    steamLink = m.Value;

                if (gameUrl != "" && steamLink != "")
                    break;
            }
        }

        private string GetNoteAttribute(XmlNode node , string name)
        {
            return node.SelectSingleNode(name) != null ? node.SelectSingleNode(name).InnerText : "";
        }

        private void CloseX_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Properties.Settings.Default.HideOnClose)
                this.Hide();
            else
                this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ChronoLink_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://chrono.gg/" + Properties.Settings.Default.Partner);
        }

        private void SteamButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(SteamUrl);
        }

        private void SettingsButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GameCanvas.Visibility == System.Windows.Visibility.Visible)
            {
                GameCanvas.Visibility = System.Windows.Visibility.Hidden;
                SettingsCanvas.Margin = new Thickness(10, 45, 0, 0);
            }
            else
            {
                GameCanvas.Visibility = System.Windows.Visibility.Visible;
                SettingsCanvas.Margin = new Thickness(225, 45, 0, 0);
            }
        }


        private void LoadSettings()
        {
            PartnerTextBox.Text = Properties.Settings.Default.Partner;
            StarOnBootCheckBox.IsChecked = Properties.Settings.Default.StarOnBoot;
            HideOnCloseCheckBox.IsChecked = Properties.Settings.Default.HideOnClose;
            ShowOnNewGameCheckBox.IsChecked = Properties.Settings.Default.ShowOnNewGame;
        }

        private void PartnerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.Partner = PartnerTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void HideOnCloseChanged(object sender, RoutedEventArgs e)
        {
            bool isCheck = HideOnCloseCheckBox.IsChecked ?? false;

            double opacity = isCheck ? 1.0 : 0.5;
            PopOnNewGameLable.Opacity = opacity;
            ShowOnNewGameCheckBox.Opacity = opacity;

            ShowOnNewGameCheckBox.IsHitTestVisible = isCheck;
            ShowOnNewGameCheckBox.Focusable = isCheck;

            if(!isCheck)
                ShowOnNewGameCheckBox.IsChecked = false;

            Properties.Settings.Default.HideOnClose = isCheck;
            Properties.Settings.Default.Save();
           
        }

        private void StarOnBootChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.StarOnBoot = StarOnBootCheckBox.IsChecked ?? false;
            Properties.Settings.Default.Save();
        }

        private void ShowOnNewGameChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowOnNewGame = ShowOnNewGameCheckBox.IsChecked ?? false;
            Properties.Settings.Default.Save();
        }

    }
}
