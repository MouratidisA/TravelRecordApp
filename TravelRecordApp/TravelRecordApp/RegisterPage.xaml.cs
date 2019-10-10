using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if (PasswordEntry.Text == ConfirmPasswordEntry.Text)
            {
                //
            }
            else
            {
                DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}