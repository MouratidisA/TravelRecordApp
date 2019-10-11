using System;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class RegisterNavigationCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainViewModel ViewModel { get; set; }

        public RegisterNavigationCommand(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Navigate();
        }

        
    }
}
