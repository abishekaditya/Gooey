using System.Windows;
using System.Windows.Controls;
using Expression = NCalc.Expression;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool _shouldClear = true;
        private string _x;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button) sender;
            _x = Output.Text;
            switch (bt.Name)
            {
                case "OneButton":
                    Check();
                    _x += "1";
                    break;
                case "TwoButton":
                    Check();
                    _x += "2";
                    break;
                case "ThreeButton":
                    Check();
                    _x += "3";
                    break;
                case "FourButton":
                    Check();
                    _x += "4";
                    break;
                case "FiveButton":
                    Check();
                    _x += "5";
                    break;
                case "SixButton":
                    Check();
                    _x += "6";
                    break;
                case "SevenButton":
                    Check();
                    _x += "7";
                    break;
                case "EightButton":
                    Check();
                    _x += "8";
                    break;
                case "NineButton":
                    Check();
                    _x += "9";
                    break;
                case "ZeroButton":
                    Check();
                    _x += "0";
                    break;
                case "MultiplyButton":
                    _x += "*";
                    _shouldClear = false;
                    break;
                case "DivideButton":
                    _x += "/";
                    _shouldClear = false;
                    break;
                case "AddButton":
                    _x += "+";
                    _shouldClear = false;
                    break;
                case "SubtractButton":
                    _x += "-";
                    _shouldClear = false;
                    break;
                case "ClearButton":
                    _x = "";
                    _shouldClear = false;
                    break;
                case "EquateButton":
                {
                        try
                        {
                            var expr = new Expression(Output.Text);
                            _x = expr.Evaluate().ToString();
                            _shouldClear = true;
                        }
                    catch
                    {
                        _x = "Error";
                        _shouldClear = true;
                    }
                }
                    break;
                case "DotButton":
                    Check();
                    _x += ".";
                    break;
                case "DeleteButton":
                    if(_x != "")
                   _x = Output.Text.Substring(0,Output.Text.Length-1);
                    break;
            }
            Output.Text = _x;

        }

        private void Check()
        {
            if (_shouldClear)
            {
                _x = "";
                Output.Text = "";
            }
            _shouldClear = false;
        }
    }
}
