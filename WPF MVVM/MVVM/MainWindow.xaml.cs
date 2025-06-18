using MVVM.ViewModel;
using MVVM.Services;
using System.Windows;

namespace MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DialogService dialogService = new DialogService();

            MainWindowViewModel vm = new MainWindowViewModel(dialogService);
            DataContext = vm;
        }
    }
}