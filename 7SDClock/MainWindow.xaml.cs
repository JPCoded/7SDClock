#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            _timer.Tick += _timer_Tick1;
            _timer.Interval = new TimeSpan(0, 0, 5);
            _timer.Start();
            
        
        }

        private void _timer_Tick1(object sender, EventArgs e)
        {
            var hours = DateTime.Now.Hour;
            var minutes = DateTime.Now.Minute;
            if (hours > 12)
            {
                hours -= 12;
            }

            var hourDigits = GetDigits(hours);
            var minuteDigits = GetDigits(minutes);
            DigitHourTens.SetNumber(hourDigits[0]);
            DigitHourOnes.SetNumber(hourDigits[1]);
            DigitMinutesTens.SetNumber(minuteDigits[0]);
            DigitMinutesOnes.SetNumber(minuteDigits[1]);
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

        private void Sliders_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DigitHourOnes.SetSegColor((byte)SlRed.Value, (byte)SlGreen.Value, (byte)SlBlue.Value);
            DigitHourTens.SetSegColor((byte)SlRed.Value, (byte)SlGreen.Value, (byte)SlBlue.Value);
            DigitMinutesOnes.SetSegColor((byte)SlRed.Value, (byte)SlGreen.Value, (byte)SlBlue.Value);
            DigitMinutesTens.SetSegColor((byte)SlRed.Value, (byte)SlGreen.Value, (byte)SlBlue.Value);
            SegColon.SetColonColor((byte)SlRed.Value, (byte)SlGreen.Value, (byte)SlBlue.Value);
        }
    }
}