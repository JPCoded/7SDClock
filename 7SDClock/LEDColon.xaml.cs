#region

using System.Windows.Controls;
using System.Windows.Media;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for LEDColon.xaml
    /// </summary>
    public partial class LedColon : UserControl
    {
        public LedColon()
        {
            InitializeComponent();
        }

        private ColonState GetColonState { get; set; }

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