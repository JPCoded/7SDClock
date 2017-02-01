#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int OpenWidth = 465;
        private const int ClosedWidth = 395;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private bool IsPropertiesShown { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Width = ClosedWidth;
            _timer.Tick += _timer_Tick1;
            _timer.Interval = new TimeSpan(0, 0, 3);
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
            var color = new Color {R = (byte)SlRed.Value,G = (byte)SlGreen.Value,B = (byte)SlBlue.Value, A = 255 };
            var colorBrush = new SolidColorBrush(color);
            
            DigitHourOnes.SegColor = colorBrush;
            DigitHourOnes.SetNumber();
            DigitHourTens.SegColor = colorBrush;
            DigitHourTens.SetNumber();
            DigitMinutesOnes.SegColor = colorBrush;
            DigitMinutesOnes.SetNumber();
            DigitMinutesTens.SegColor = colorBrush;
            DigitMinutesTens.SetNumber();

           SegColon.SetColonColor(colorBrush);
        }

        private void btnChangeWidth_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = IsPropertiesShown ? ClosedWidth : OpenWidth ;
            btnChangeWidth.Content = IsPropertiesShown ? ">" : "<";
            IsPropertiesShown ^= true;
        }
    }
}