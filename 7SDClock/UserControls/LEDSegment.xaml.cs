#region

using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for LEDSegment.xaml
    /// </summary>
    public partial class LedSegment
    {
        private SolidColorBrush _segColorBrush = Brushes.Red;

        private readonly Dictionary<int, List<char>> _numbersDictonary = new Dictionary<int, List<char>>
        {
            {0, new List<char> {'A', 'B', 'C', 'D', 'E', 'F'}},
            {1, new List<char> {'B', 'C'}},
            {2, new List<char> {'A', 'B', 'D', 'E', 'G'}},
            {3, new List<char> {'A', 'B', 'C', 'D', 'G'}},
            {4, new List<char> {'B', 'C', 'F', 'G'}},
            {5, new List<char> {'A', 'C', 'D', 'F', 'G'}},
            {6, new List<char> {'C', 'D', 'E', 'F', 'G'}},
            {7, new List<char> {'A', 'B', 'C'}},
            {8, new List<char> {'A', 'B', 'C', 'D', 'E', 'F', 'G'}},
            {9, new List<char> {'A', 'B', 'C', 'F', 'G'}}
        };

        private readonly Dictionary<char, Polygon> _segmentsDictonary;

        public LedSegment()
        {
            InitializeComponent();

            _segmentsDictonary = new Dictionary<char, Polygon>
            {
                {'A', SegA},
                {'B', SegB},
                {'C', SegC},
                {'D', SegD},
                {'E', SegE},
                {'F', SegF},
                {'G', SegG}
            };
        }

        private int SegNumber { get; set; }

        public SolidColorBrush SegColor
        {
            private get { return _segColorBrush; }
            set
            {
                SetNumber();
                _segColorBrush = value;
            }
        }

        public void SetNumber(int? numberToSet = null)
        {
            numberToSet = numberToSet ?? SegNumber;
            {
                SegNumber = numberToSet.GetValueOrDefault();
                var characters = _numbersDictonary[numberToSet.GetValueOrDefault()];
                foreach (var seg in _segmentsDictonary)
                {
                    seg.Value.Fill = characters.Contains(seg.Key) ? SegColor : Brushes.LightGray;
                }
            }
        }
    }
}