using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Password_Generator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        private bool useUpperCase = false;
        private bool useLoverCase = true;
        private bool useNumbers = false;
        private bool useSpecialChars = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {   
            DragMove();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;

            int conventer = Convert.ToInt32(PasswordLenth.Value);

            PasswordLenthText.Text = conventer.ToString();
            
        }

        public static string GeneratePassword(int length , bool _useUpperCase = false,bool _useLoverCase = false ,bool _useNumbers = false, bool _useSpecialChars = false)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string specialChars = "!@#$%^&*()_+=-[]{}|;:,.<>?";

            StringBuilder sb = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                string charSet = null;
                if (_useLoverCase) 
                    charSet += lowercase;
                if (_useUpperCase)
                    charSet += uppercase;
                if (_useNumbers)
                    charSet += numbers;
                if (_useSpecialChars)
                    charSet += specialChars;

                int randomIndex = random.Next(charSet.Length);
                sb.Append(charSet[randomIndex]);
            }

            return sb.ToString();
        }

        private void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!useUpperCase & !useLoverCase & !useNumbers & !useSpecialChars)
            {
                MessageBox.Show("Выберити хотя бы одно из свойств паролей");
            }
            else
            {
                ReadyPassword.Text = GeneratePassword(Convert.ToInt32(PasswordLenthText.Text), useUpperCase, useLoverCase, useNumbers, useSpecialChars);
            }

        }

        private void UseUpperCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            useUpperCase = false;
            Debug.Write("false");
        }

        private void UseLowerCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            useLoverCase = false;
        }

        private void UseNumbersCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            useNumbers = false;
        }

        private void UseSpecialCharsCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            useSpecialChars = false;
        }

        private void UseUpperCheck_Checked(object sender, RoutedEventArgs e)
        {
            useUpperCase = true;
        }

        private void UseLowerCheck_Checked(object sender, RoutedEventArgs e)
        {
            useLoverCase = true;
        }

        private void UseNumbersCheck_Checked(object sender, RoutedEventArgs e)
        {
            useNumbers = true;
        }

        private void UseSpecialCharsCheck_Checked(object sender, RoutedEventArgs e)
        {
            useSpecialChars = true;
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Ellipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Border_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ReadyPassword.Text != "Нажмите на кнопку")
            {
                Clipboard.SetText(ReadyPassword.Text);
                MessageBox.Show("Пароль скопирован!");
            }
            else
            {
                MessageBox.Show("Сначала сгенерируйте пароль!");
            }
        }
    }
}
