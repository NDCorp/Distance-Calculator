using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
