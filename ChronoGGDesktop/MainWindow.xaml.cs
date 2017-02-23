using Microsoft.Win32;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using System.Windows.Forms;


namespace ChronoGGDesktopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer NewGameTimer = new DispatcherTimer();

        bool loadedOk = true;
        string SteamUrl;

        public MainWindow()
        {
            InitializeComponent();           
            this.ShowActivated = false;
            this.Width = 220;

            LoadSettings();

            GetRSSData();                       
            StartDailyTimer();
            CreateNotifyIcon();
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
            NewGameTimer.Interval = new TimeSpan(0, targetMinutes , 0);
            NewGameTimer.Start();
        }

        private void CreateNotifyIcon()
        {
            ToolStripMenuItem[] items = new ToolStripMenuItem[] { new ToolStripMenuItem(), new ToolStripMenuItem() };
            items[0].Text = "Show";
            items[0].Click += new EventHandler(NotifyShow);
            items[1].Text = "Exit";
            items[1].Click += new EventHandler(NotifyExit);

            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.Chrono;
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.AddRange(items);
            notifyIcon.Visible = true;
            notifyIcon.Click += NotifyIcon_Click;
        }

        private void NotifyIcon_Click(object sender, System.EventArgs e)
        {
            NotifyIcon notifyIcon = (NotifyIcon)sender;
            notifyIcon.ContextMenuStrip.Show(System.Windows.Forms.Control.MousePosition);          
        }

        private void NotifyShow(object sender, EventArgs e)
        {
            this.Show();
        }

        private void NotifyExit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GetRSSData();
            NewGameTimer.Interval = new TimeSpan(24, 0, 0);

            if(Properties.Settings.Default.ShowOnNewGame)
                this.Show();            
        }

        private void PlaceLowerRight()
        {
            Rect desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width - 10;
            this.Top = desktopWorkingArea.Bottom - this.Height - 10;
        }

        private void GetRSSData()
        {
            try
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
            catch
            {
                loadedOk = false;
                TitleTextBox.Text = "Unable to read rss";
            }
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
            OpenUrl("https://chrono.gg/" + Properties.Settings.Default.Partner);
        }

        private void SteamButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenUrl(SteamUrl);
        }

        private void OpenUrl(string url)
        {
            if (loadedOk)
                System.Diagnostics.Process.Start(url);
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
            RegisterInStartup(Properties.Settings.Default.StarOnBoot);
            Properties.Settings.Default.Save();
        }

        private void ShowOnNewGameChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowOnNewGame = ShowOnNewGameCheckBox.IsChecked ?? false;
            Properties.Settings.Default.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] coords = Properties.Settings.Default.Postion.Split(',');
            if(coords.Length == 2)
            {
                this.Left = int.Parse(coords[0]);
                this.Top = int.Parse(coords[1]);
            }
            else
            {
                PlaceLowerRight();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.Postion = this.Left + "," + this.Top;
            Properties.Settings.Default.Save();
        }

        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            Assembly curAssembly = Assembly.GetExecutingAssembly();
           
            if (isChecked)
            {
                registryKey.SetValue(curAssembly.GetName().Name, curAssembly.Location);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }
    }
}
