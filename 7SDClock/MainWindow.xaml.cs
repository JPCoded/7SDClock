#region

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
            if (_currentNumber > 12)
            {
                _currentNumber = 0;
            }
            if (_currentNumber > 9)
            {
                var newDigits = getDigits(_currentNumber);
                DigitHourTens.SetNumber(newDigits[0]);
                DigitHourOnes.SetNumber(newDigits[1]);
            }
            else
            {
                DigitHourTens.SetNumber(0);
                DigitHourOnes.SetNumber(_currentNumber);
            }
            _currentNumber++;
        }

        private static int[] getDigits(int digitToBreak)
        {
            var count = 2;
            var digits = new int[2];
            while (count-- != 0)
            {
                digits[count] = digitToBreak%10;
                digitToBreak /= 10;
            }
            return digits;
        }
    }
}