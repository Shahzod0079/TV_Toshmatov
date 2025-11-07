using System;
using System.Windows;
using System.Windows.Threading;

namespace TV_Toshmatov
{
    public partial class MainWindow : Window
    {
        Classes.TV TV = new Classes.TV();

        private DispatcherTimer autoSwitchTimer;

        public MainWindow()
        {
            InitializeComponent();

            VideoPlayer.Source = new Uri(TV.Channels[TV.ActiveChannel].Src);
            NameChannel.Content = TV.Channels[TV.ActiveChannel].Name;

            VideoPlayer.Play();

            InitializeAutoSwitchTimer();
        }

        private void InitializeAutoSwitchTimer()
        {
            autoSwitchTimer = new DispatcherTimer();

            autoSwitchTimer.Interval = TimeSpan.FromSeconds(10);
            autoSwitchTimer.Tick += AutoSwitchTimer_Tick;
  
            autoSwitchTimer.Start();
        }

        private void AutoSwitchTimer_Tick(object sender, EventArgs e)
        {
            TV.NextChannel(VideoPlayer, NameChannel);
        }

        private void BackChannel(object sender, RoutedEventArgs e)
        {
            TV.BackChannel(VideoPlayer, NameChannel);
        }

        private void NextChannel(object sender, RoutedEventArgs e)
        {
            TV.NextChannel(VideoPlayer, NameChannel);
        }

        private void ToggleAutoSwitch(object sender, RoutedEventArgs e)
        {
            if (autoSwitchTimer.IsEnabled)
            {
                autoSwitchTimer.Stop();
            }
            else
            {
                autoSwitchTimer.Start();
            }
        }
    }
}