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
            if (_currentNumber > 59)
            {
                _currentNumber = 0;
            }

                var newDigits = GetDigits(_currentNumber);
                DigitHourTens.SetNumber(newDigits[0]);
                DigitHourOnes.SetNumber(newDigits[1]);

            _currentNumber++;
        }

        private static int[] GetDigits(int digitToBreak)
        {
            var count = 2;
            var digits = new[] {0,0};
            while (count-- != 0)
            {
                digits[count] = digitToBreak%10;
                digitToBreak /= 10;
            }
            return digits;
        }
    }
}