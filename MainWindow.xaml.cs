using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szamologep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GombokElhelyezese();
        }

        private void GombokElhelyezese()
        {
            for (int i = 0; i < 4; i++)
            {
                ButtonGrid.RowDefinitions.Add(new RowDefinition());
                ButtonGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            string[,] feliratok = new string[4, 4]
                {
                    { "7", "8", "9", "/" },
                    { "4", "5", "6", "*" },
                    { "1", "2", "3", "-" },
                    { "C", "0", "=", "+" }
                };

            for (int i = 0; i < 4; i++) //Row
            {
                for (int j = 0; j < 4; j++) //Column
                {
                    string label = feliratok[i, j];
                    Button btn = new Button
                    {
                        Content = label,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(3)
                    };
                    if (char.IsDigit(label[0]))
                    {
                        btn.Background = Brushes.WhiteSmoke;
                    }
                    else if(label == "C")
                    {
                        btn.Background = Brushes.IndianRed;
                        btn.Foreground = Brushes.White;
                    }
                    else
                    {
                        btn.Background = Brushes.DodgerBlue;
                        btn.Foreground = Brushes.White;
                    }

                    btn.Click += Button_Click;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);

                    ButtonGrid.Children.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            List<int> numbers = new List<int>();

            // Get the content of the clicked button
            // Try to do it like this:
            // ClickedButton -> List
            // Try to solve the whole equation.
            // If not possible, then just get the contect like if(+) or (-) or (*) or (/)
            // and then just get the numbers before and after the operator.
            // Then solve the equation and display the result in the textbox.





            string buttonContent = button.Content.ToString();
            tb_kijelzo.Text += buttonContent;

            bool isOperator = buttonContent == "+" || buttonContent == "-" || buttonContent == "*" || buttonContent == "/";
            bool isClear = buttonContent == "C";
            bool isEquals = buttonContent == "=";
            bool isDigit = char.IsDigit(buttonContent[0]);

            string inputDigit = "";
            string part2 = "";

            int firstToEquation = 0;

            if (isDigit) {
                if (inputDigit != "")
                {
                    inputDigit = "";
                    tb_kijelzo.Text += inputDigit;
                }
                inputDigit += buttonContent;
                tb_kijelzo.Text += inputDigit;
            }
            else if (isOperator) {
                if (tb_kijelzo.Text.Length > 0 && !"+-*/".Contains(tb_kijelzo.Text[tb_kijelzo.Text.Length - 1]))
                {
                    return;
                }
                tb_kijelzo.Text += buttonContent;
                firstToEquation = Convert.ToInt32(inputDigit);
            }
        } 
    }
}