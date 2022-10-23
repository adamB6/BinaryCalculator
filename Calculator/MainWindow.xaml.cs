/*
 * Adam Botens
 * CSCI 3005
 * Assignment 4
 * 
 * A Binary Calculator that is capable of basic math and bitwise operations.
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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
        /// <summary>
        /// Event handler used to clear textboxes.
        /// </summary>
        /// <param name="sender">One of the clear buttons.</param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// Event handler used for event of basic operator buttons being clicked.
        /// </summary>
        /// <param name="sender">One of the basic operator buttons.</param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentException"></exception>
        private void BasicOperators_Click(object sender, RoutedEventArgs e)
        {
            if (!ErrorCheck())
            {
                return;
            }
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
        /// <summary>
        /// Event handler used for event of bitwise operator buttons being clicked.
        /// </summary>
        /// <param name="sender">One of the bitwise operator buttons.</param>
        /// <param name="e"></param>
        private void BitWiseOperators_click(object sender, RoutedEventArgs e)
        {

            if (ReferenceEquals(sender, OrButton))
            {
                if (!ErrorCheck())
                {
                    return;
                }
                string binaryString1 = TextBox1.Text;
                int value1 = Convert.ToInt32(binaryString1, 2);

                string binaryString2 = TextBox2.Text;
                int value2 = Convert.ToInt32(binaryString2, 2);

                int or = value1 | value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} | {Convert.ToString(value2, 2)} = {Convert.ToString(or, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} | {Convert.ToString(value2, 10)} = {Convert.ToString(or, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} | {Convert.ToString(value2, 8)} = {Convert.ToString(or, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16)} | {Convert.ToString(value2, 16)} = {Convert.ToString(or, 16).ToUpper()}";
            }
            else if(ReferenceEquals(sender, AndButton))
            {
                if (!ErrorCheck())
                {
                    return;
                }
                string binaryString1 = TextBox1.Text;
                int value1 = Convert.ToInt32(binaryString1, 2);

                string binaryString2 = TextBox2.Text;
                int value2 = Convert.ToInt32(binaryString2, 2);

                int and = value1 & value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} & {Convert.ToString(value2, 2)} = {Convert.ToString(and, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} & {Convert.ToString(value2, 10)} = {Convert.ToString(and, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} & {Convert.ToString(value2, 8)} = {Convert.ToString(and, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16)} & {Convert.ToString(value2, 16)} = {Convert.ToString(and, 16).ToUpper()}";
            }
            else if (ReferenceEquals(sender, XorButton))
            {
                if (!ErrorCheck())
                {
                    return;
                }
                string binaryString1 = TextBox1.Text;
                int value1 = Convert.ToInt32(binaryString1, 2);

                string binaryString2 = TextBox2.Text;
                int value2 = Convert.ToInt32(binaryString2, 2);

                int xor = value1 ^ value2;
                TextBoxBin.Text = $"{Convert.ToString(value1, 2)} ^ {Convert.ToString(value2, 2)} = {Convert.ToString(xor, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} ^ {Convert.ToString(value2, 10)} = {Convert.ToString(xor, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} ^ {Convert.ToString(value2, 8)} = {Convert.ToString(xor, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16)} ^ {Convert.ToString(value2, 16)} = {Convert.ToString(xor, 16).ToUpper()}";
            }
            else if (ReferenceEquals(sender, NotButton))
            {
                if (TextBox1.Text.Length < 1)
                {
                    MessageBox.Show("Number 1 must have a value.");
                    return;
                }
                string binaryString1 = TextBox1.Text;
                int value1 = Convert.ToInt32(binaryString1, 2);

                TextBox2.Text = "";
                TextBoxBin.Text = $"~{Convert.ToString(value1, 2)} = {Convert.ToString(~value1, 2)}";
                TextBoxDecimal.Text = $"{Convert.ToString(value1, 10)} = {Convert.ToString(~value1, 10)}";
                TextBoxOctal.Text = $"{Convert.ToString(value1, 8)} = {Convert.ToString(~value1, 8)}";
                TextBoxHex.Text = $"{Convert.ToString(value1, 16)} = {Convert.ToString(~value1, 16)}";
            }

        }
        /// <summary>
        /// Ensures that only 0s and 1s are entered in the text boxes.
        /// </summary>
        /// <param name="sender">Textbox1 and Textbox2</param>
        /// <param name="e"></param>
        private void BinaryOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Checks that whether each textbox has a value. 
        /// </summary>
        /// <returns>Returns true or false.</returns>
        private bool ErrorCheck()
        {
            if (TextBox1.Text.Length < 1 && TextBox2.Text.Length < 1)
            {
                MessageBox.Show("Number 1 and Number 2 must have values.");
                return false;
            }
            else if (TextBox1.Text.Length < 1)
            {
                MessageBox.Show("Number 1 must have a value.");
                return false;
            }
            else if (TextBox2.Text.Length < 1)
            {
                MessageBox.Show("Number 2 must have a value.");
                return false;
            }
            return true;
        }
    }
}
