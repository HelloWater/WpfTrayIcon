namespace NotificationIconSample
{
    using System;
    using System.Windows;

    using System.Windows.Forms; // NotifyIcon control
    using System.Drawing; // Icon
   
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation=WindowStartupLocation.CenterScreen;
            CreateTrayIcon();
        }

        private void ShowMe()
        {
            //System.Windows.MessageBox.Show("Show Me");
            this.Show();
        }
        private void HideMe()
        {
            //System.Windows.MessageBox.Show("Hide Me");
            this.Hide();
        }
        private void ClickTrayIcon()
        {
            if(this.IsVisible)
            {
                HideMe();
            }
            else
            {
                ShowMe();
            }
        }
       
        private void CreateTrayIcon()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = new System.Drawing.Icon("notify.ico"),
                Text = "Hello NotifyIcon",
                BalloonTipText = "Hello NotifyIcon"
            };
            notifyIcon.Visible = true;

            ContextMenu menu = new ContextMenu();

            MenuItem showItem = new MenuItem();
            showItem.Text = "Show";
            showItem.Click += new EventHandler(delegate { ShowMe();});

            MenuItem HideItem = new MenuItem();
            HideItem.Text = "Hide";
            HideItem.Click += new EventHandler(delegate { HideMe(); });

            menu.MenuItems.Add(showItem);
            menu.MenuItems.Add(HideItem);

            notifyIcon.ContextMenu = menu;
            notifyIcon.Click += new EventHandler(delegate { ClickTrayIcon(); });
        }

        void clickMainWndImg(object sender, RoutedEventArgs e)
        {
            // Configure and show a notification icon in the system tray
            
            this.notifyIcon.ShowBalloonTip(1000);
        }
    }
}