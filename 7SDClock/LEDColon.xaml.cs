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

        public void SetColonColor(byte red, byte green, byte blue)
        {
            var color = new Color {R = red,B=blue,G=green,A=255};

            Segonecolor.Value = color;
            Segtwocolor.Value = color;
        }
    }
}