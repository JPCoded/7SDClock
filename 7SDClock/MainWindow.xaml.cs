#region

using System.Windows;

#endregion

namespace _7SDClock
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentNumber = 0;
        public MainWindow()
        {
            InitializeComponent();
        
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 9)
            {
                currentNumber = 0;
            }
            DigitHourTens.SetNumber(currentNumber);
            currentNumber++;
        }
    }
}