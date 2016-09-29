namespace GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1
    {
        public Window1(string name)
        {
            InitializeComponent();
            label.Content = "Hello, " + name;
        }
    }
}
