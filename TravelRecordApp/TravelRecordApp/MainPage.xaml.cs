using System;
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

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
           bool isEmailEmpty= string.IsNullOrEmpty(EmailEntry.Text);
           bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);


           if (isEmailEmpty||isPasswordEmpty)
           {

           }
           else
           {
               Navigation.PushAsync(new HomePage());
           }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
