using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Progress
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void Progressor(int start)
        {
            Progress.Value = start;
            for (var i = start; i >= 0; i -=2)
            {
                var i1 = i;
                Progress.Foreground =
                    new SolidColorBrush(Interpolate(Colors.Green, Colors.Red,(double)i1/100));

                Progress.Dispatcher.Invoke(() => Progress.Value = i1, DispatcherPriority.Background);
                Thread.Sleep(50);
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Progressor(100);
        }

        private void MainWindow_OnContentRendered(object sender, EventArgs e)
        {
            Progressor(50);
        }

        public static Color Interpolate(Color source, Color target, double percent)
        {
            var r = (byte)(source.R + (target.R - source.R) * percent);
            var g = (byte)(source.G + (target.G - source.G) * percent);
            var b = (byte)(source.B + (target.B - source.B) * percent);

            return Color.FromArgb(255, r, g, b);
        }
    }
}
