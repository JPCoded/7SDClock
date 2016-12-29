#region

using System.Collections.Generic;
using System.Windows;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _currentNumber;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (_currentNumber > 59)
            {
                _currentNumber = 0;
            }

            var newDigits = GetDigits(_currentNumber);
            DigitHourTens.SetNumber(newDigits[0]);
            DigitHourOnes.SetNumber(newDigits[1]);

            _currentNumber++;
        }

        private static List<int> GetDigits(int digitToSeperate)
        {
            //figure way to make this dynamic
            var count = 2;
            var digits = new List<int>();
            while (count-- != 0)
            {
               digits.Add(digitToSeperate%10);
                digitToSeperate /= 10;
            }
             digits.Reverse();
            return digits;
        }
    }
}