#region

using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for LEDColon.xaml
    /// </summary>
    public partial class LedColon : UserControl
    {
        private Brush ColorBrush { get; set; } = Brushes.Red;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private bool IsBlink { get; set; } = false;
        public LedColon()
        { 
            InitializeComponent();
            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
           
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            IsBlink ^= true;
           ChangeColonColors();

        }

        private void ChangeColonColors()
        {
            SegCol1.Fill = IsBlink ? ColorBrush : Brushes.LightGray;
            SegCol2.Fill = IsBlink ? ColorBrush : Brushes.LightGray;
        }
        public void SetColonColor(Brush newColor)
        {
           ColorBrush = newColor;
            ChangeColonColors();
           
        }
    }
}