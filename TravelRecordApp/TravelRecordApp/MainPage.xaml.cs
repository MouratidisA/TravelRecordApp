using System;
using System.Linq;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            IconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);


            if (isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == EmailEntry.Text).ToListAsync()).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == PasswordEntry.Text)
                        await Navigation.PushAsync(new HomePage());
                    else
                        await DisplayAlert("Error", "Email or Password are incorrect", "Ok");
                }
                else
                    await DisplayAlert("Error", "There was an error logging you in", "Ok");
            }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
