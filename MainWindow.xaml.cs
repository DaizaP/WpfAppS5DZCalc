using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppS5DZCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            calculator.Result += Calculator_Result;
        }

        private void Calculator_Result(object sender, CalculatorArgs e)
        {
            LabelOutAnswer.Content = e.answer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool parse = int.TryParse(TextBoxInputText.Text, out int value);
            string name = (e.Source as FrameworkElement).Name;
            if (!parse)
            {
                MessageBox.Show("Неверно ввели данные");
                TextBoxInputText.Clear();
            }
            switch (name)
            {
                case "ButtonAdd":
                    calculator.Add(value); break;
                case "ButtonSub":
                    calculator.Sub(value); break;
                case "ButtonMult":
                    calculator.Mult(value); break;
                case "ButtonDiv":
                    calculator.Div(value); break;
                default:
                    MessageBox.Show("Ошибка нажатия");
                    TextBoxInputText.Clear();
                    break;
            }
        }

        private void TextBoxInputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = TextBoxInputText.Text;

            if (!int.TryParse(str, out int v))
            {
                string result = new string(str.Where(t => char.IsDigit(t)).ToArray());
                TextBoxInputText.Text = result;
                TextBoxInputText.Select(TextBoxInputText.Text.Length, 0);
            }
        }
    }
}
