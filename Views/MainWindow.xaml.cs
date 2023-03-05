using System.Windows;
using Diachenko_01.ViewModels;

namespace Diachenko_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BirthdateViewModel();
        }
    }
}
