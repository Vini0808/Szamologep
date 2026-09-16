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
            string buttonContent = button.Content.ToString();
            tb_kijelzo.Text += buttonContent;
        }
    }
}