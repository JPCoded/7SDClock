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

        private void TurnColonOn()
        {
            SegCol1.Fill = Brushes.Red;
            SegCol2.Fill = Brushes.Red;
        }

        private void TurnColonOff()
        {
            SegCol1.Fill = Brushes.LightGray;
            SegCol2.Fill = Brushes.LightGray;
        }
    }
}