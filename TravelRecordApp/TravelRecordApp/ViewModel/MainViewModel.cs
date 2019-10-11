using System.ComponentModel;
using System.Runtime.CompilerServices;
using TravelRecordApp.Annotations;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {                
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginCommand LoginCommand { set; get; }
        public RegisterNavigationCommand RegisterNavigationCommand { set; get; }

        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;               
                OnPropertyChanged("User");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                User = new User(){Email = this.Email,Password = this.Password};
                OnPropertyChanged("Email");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                User = new User() { Email = this.Email, Password = this.Password };
                OnPropertyChanged("Password");
            }
        }

        
        public MainViewModel()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
            RegisterNavigationCommand=new RegisterNavigationCommand(this);
        }

        public async void Login()
        {
            if (await User.Login(User.Email, User.Password))
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

                
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
