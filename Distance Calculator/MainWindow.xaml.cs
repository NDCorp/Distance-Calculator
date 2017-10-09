using System.Windows;
using System.Windows.Input;

namespace Distance_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VMDistance VM;
        private string msgErr;

        public MainWindow()
        {
            InitializeComponent();
            VM = new VMDistance();
            DataContext = VM;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            VM.CalculateDistance(ref msgErr);
            VM.WriteFile(msgErr);
        }

        //Lock the minus symbol
        private void txtSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
                e.Handled = true;
        }

        private void txtTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
                e.Handled = true;
        }
    }
}
