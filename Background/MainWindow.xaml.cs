using System.Windows.Media;

namespace Background
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
           
            var l = new LinearGradientBrush();
            var gs = new GradientStop
            {
                Offset = 0.5,
                Color = Color.FromRgb(212, 255, 201)
            };

            var bs = new GradientStop
            {
                Offset = 0.8,
                Color = Colors.Coral
            };
            l.GradientStops.Add(gs);
            l.GradientStops.Add(bs);
            Gradient.Background = l;
        }
    }
}
