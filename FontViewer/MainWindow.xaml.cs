using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace FontViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            string[] fontfamilies = FindResource(Fonts.SystemFontFamilies) as string[];
            var view = CollectionViewSource.GetDefaultView(fontfamilies);
            new TextSearchFilter(view, searcher);
        }
        
    }

    public class TextSearchFilter
    {
       public TextSearchFilter(System.ComponentModel.ICollectionView filteredview, TextBox textbox)
        {
            string FilteredText = "";

            filteredview.Filter = delegate (object obj)
            {
                if (String.IsNullOrEmpty(FilteredText))
                {
                    return true;
                }

                string str = obj as string;
                if (String.IsNullOrEmpty(str))
                {
                    return false;
                }

                int index = str.IndexOf(FilteredText, 0, StringComparison.InvariantCultureIgnoreCase);
                return index > 1;
            };

            textbox.TextChanged += delegate
            {
                FilteredText = textbox.Text;
                filteredview.Refresh();
            };

        }
    }


}
