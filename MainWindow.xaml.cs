using System;
using System.Windows;

namespace TV_Toshmatov
{
    public partial class MainWindow : Window
    {
        Classes.TV TV = new Classes.TV();

        public MainWindow()
        {
            InitializeComponent();
            VideoPlayer.Source = new Uri(TV.Channels[TV.ActiveChannel].Src);
            NameChannel.Content = TV.Channels[TV.ActiveChannel].Name;
            VideoPlayer.Play();
        }

        private void BackChannel(object sender, RoutedEventArgs e)
        {
            TV.BackChannel(VideoPlayer, NameChannel);
        }
        private void NextChannel(object sender, RoutedEventArgs e)
        {
            TV.NextChannel(VideoPlayer, NameChannel);
        }
    }
}