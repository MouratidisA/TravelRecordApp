using System;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel.Commands
{
    public class PostCommand : ICommand
    {
        private NewTravelViewModel ViewModel;


        public PostCommand(NewTravelViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;
            if (post != null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                    return false;

                if (post.Venue != null)
                    return true;

                return false;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            ViewModel.PublishPost(post);
        }

        public event EventHandler CanExecuteChanged;
    }
}
