using System.Windows;
using System.Windows.Input;

/*
 * COMMENTS:
 * Use Enum to manage errors and show the message on the view side
 * No message in the VM side
 * 
 */
namespace Distance_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VMDistance VM;

        public MainWindow()
        {
            InitializeComponent();
            VM = new VMDistance();
            DataContext = VM;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            VM.CalculateDistance();
            VM.WriteFile();
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
