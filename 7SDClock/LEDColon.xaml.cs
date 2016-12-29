#region

using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for LEDColon.xaml
    /// </summary>
    public partial class LedColon : UserControl
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public LedColon()
        {
            InitializeComponent();
            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 1);
        }

        private ColonState GetColonState { get; set; }

        public void StartColon()
        {
            _timer.Start();
        }

        public void StopColon()
        {
            _timer.Stop();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (GetColonState == ColonState.On)
            {
                TurnColonOff();
            }
            else
            {
                TurnColonOn();
            }
        }

        private void TurnColonOn()
        {
            if (GetColonState == ColonState.Off)
            {
                SegCol1.Fill = Brushes.Red;
                SegCol2.Fill = Brushes.Red;
                GetColonState = ColonState.On;
            }
        }

        private void TurnColonOff()
        {
            if (GetColonState == ColonState.On)
            {
                SegCol1.Fill = Brushes.LightGray;
                SegCol2.Fill = Brushes.LightGray;
                GetColonState = ColonState.Off;
            }
        }

        private enum ColonState
        {
            On,
            Off
        };
    }
}