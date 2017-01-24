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
        public Color myColor { get; set; } = Color.FromRgb(255,0,0);
        public LedColon()
        {
            InitializeComponent();
           // Segonecolor.Value = Color.from
        }

        public void SetColonColor(Color newColor)
        {
        
           // Segonecolor.Value = newColor;
           // Segtwocolor.Value = newColor;
        }
    }
}