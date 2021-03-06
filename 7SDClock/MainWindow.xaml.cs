﻿#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const int OpenWidth = 465;
        private const int ClosedWidth = 395;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private readonly Func<int, int> _getLength = x => (int) Math.Floor(Math.Log10(x) + 1);

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Width = ClosedWidth;
            _timer.Tick += _timer_Tick1;
            _timer.Interval = new TimeSpan(0, 0, 3);
            _timer.Start();
        }

        private bool IsPropertiesShown { get; set; }

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

        private List<int> GetDigits(int digitToSeperate)
        {
            var length = _getLength.Invoke(digitToSeperate);
            var count = length < 2 ? 2 : length;
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
            var colorBrush = new SolidColorBrush( new Color { R = (byte)SlRed.Value, G = (byte)SlGreen.Value, B = (byte)SlBlue.Value, A = 255 });

            DigitHourOnes.SegColor = colorBrush;
            DigitHourTens.SegColor = colorBrush;
            DigitMinutesOnes.SegColor = colorBrush;
            DigitMinutesTens.SegColor = colorBrush;
            SegColon.SetColonColor(colorBrush);
        }

        private void btnChangeWidth_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = IsPropertiesShown ? ClosedWidth : OpenWidth;
            btnChangeWidth.Content = IsPropertiesShown ? ">" : "<";
            IsPropertiesShown ^= true;
        }
    }
}