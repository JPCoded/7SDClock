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
           // Segonecolor.Value = Color.from
        }

        public void SetColonColor(byte red, byte green, byte blue)
        {
            var color = new Color {R = red,B=blue,G=green,A=255};
            var test = Segonecolor.Value;
            Segonecolor.Value = Color.FromRgb(red, green, blue);
            Segtwocolor.Value = color;
        }
    }
}