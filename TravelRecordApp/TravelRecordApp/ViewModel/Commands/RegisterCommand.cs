using System;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        private RegisterViewModel ViewModel;
        public event EventHandler CanExecuteChanged;

        public RegisterCommand(RegisterViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            User user = (User)parameter;

            if (user != null)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmPassword))
                        return false;

                    return true;
                }
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var user = (User) parameter;

            ViewModel.Register(user);
        }
        
    }
}
