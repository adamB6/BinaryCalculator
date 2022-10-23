using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetResourceReference(BackgroundProperty, SystemColors.ControlBrushKey);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if(ReferenceEquals(sender, ClearButton1))
            {
                TextBox1.Text = "";
            }
            else if (ReferenceEquals(sender, ClearButton2))
            {
                TextBox2.Text = "";
            }
            else if(ReferenceEquals(sender, AllClearButton))
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                throw new ArgumentException("sender has unexpected val");
            }
        }

        private void BasicOperators_Click(object sender, RoutedEventArgs e)
        {
            string binaryString1 = TextBox1.Text;
            int value1 = Convert.ToInt32(binaryString1, 2);

            string binaryString2 = TextBox2.Text;
            int value2 = Convert.ToInt32(binaryString2, 2);

            if (ReferenceEquals(sender, AddButton))
            {
                int total = value1 + value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} + {Convert.ToString(value2, 2)} = {Convert.ToString(total, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} + {Convert.ToString(value2, 10)} = {Convert.ToString(total, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} + {Convert.ToString(value2, 8)} = {Convert.ToString(total, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16).ToUpper()} + {Convert.ToString(value2, 16).ToUpper()} = {Convert.ToString(total, 16).ToUpper()}";
            }
            else if (ReferenceEquals(sender, SubButton))
            {
                int total = value1 - value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} + {Convert.ToString(value2, 2)} = {Convert.ToString(total, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} + {Convert.ToString(value2, 10)} = {Convert.ToString(total, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} + {Convert.ToString(value2, 8)} = {Convert.ToString(total, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16).ToUpper()} + {Convert.ToString(value2, 16).ToUpper()} = {Convert.ToString(total, 16).ToUpper()}";
            }
            else if (ReferenceEquals(sender, MultButton))
            {
                int total = value1 * value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} + {Convert.ToString(value2, 2)} = {Convert.ToString(total, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} + {Convert.ToString(value2, 10)} = {Convert.ToString(total, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} + {Convert.ToString(value2, 8)} = {Convert.ToString(total, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16).ToUpper()} + {Convert.ToString(value2, 16).ToUpper()} = {Convert.ToString(total, 16).ToUpper()}";
            }
            else if (ReferenceEquals(sender, DivButton))
            {
                int total = value1 / value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} + {Convert.ToString(value2, 2)} = {Convert.ToString(total, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} + {Convert.ToString(value2, 10)} = {Convert.ToString(total, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} + {Convert.ToString(value2, 8)} = {Convert.ToString(total, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16).ToUpper()} + {Convert.ToString(value2, 16).ToUpper()} = {Convert.ToString(total, 16).ToUpper()}";
            }
            else
            {
                throw new ArgumentException("sender has unexpected val");
            }

        }

        private void BitWiseOperators_click(object sender, RoutedEventArgs e)
        {
            string binaryString1 = TextBox1.Text;
            int value1 = Convert.ToInt32(binaryString1, 2);

            string binaryString2 = TextBox2.Text;
            int value2 = Convert.ToInt32(binaryString2, 2);


            if (ReferenceEquals(sender, OrButton))
            {
                int or = value1 | value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} | {Convert.ToString(value2, 2)} = {Convert.ToString(or, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} | {Convert.ToString(value2, 10)} = {Convert.ToString(or, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} | {Convert.ToString(value2, 8)} = {Convert.ToString(or, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16)} | {Convert.ToString(value2, 16)} = {Convert.ToString(or, 16).ToUpper()}";
            }
            else if(ReferenceEquals(sender, AndButton))
            {
                int and = value1 & value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} & {Convert.ToString(value2, 2)} = {Convert.ToString(and, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} & {Convert.ToString(value2, 10)} = {Convert.ToString(and, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} & {Convert.ToString(value2, 8)} = {Convert.ToString(and, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16)} & {Convert.ToString(value2, 16)} = {Convert.ToString(and, 16).ToUpper()}";
            }
            else if (ReferenceEquals(sender, XorButton))
            {
                int xor = value1 ^ value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} ^ {Convert.ToString(value2, 2)} = {Convert.ToString(xor, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} ^ {Convert.ToString(value2, 10)} = {Convert.ToString(xor, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} ^ {Convert.ToString(value2, 8)} = {Convert.ToString(xor, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16)} ^ {Convert.ToString(value2, 16)} = {Convert.ToString(xor, 16).ToUpper()}";
            }
            else if (ReferenceEquals(sender, NotButton))
            {
                TextBox2.Text = "";
                TextBoxBin.Text = $"~{Convert.ToString(value1, 2)} = {Convert.ToString(~value1, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} = {Convert.ToString(~value1, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} = {Convert.ToString(~value1, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16)} = {Convert.ToString(~value1, 16)}";
            }

        }
    }
}
