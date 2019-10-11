using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
    {        
        public RegisterViewModel RegisterViewModel  { get; set; }

		public RegisterPage ()
		{
			InitializeComponent ();
            RegisterViewModel = new RegisterViewModel();
            BindingContext = RegisterViewModel;
        }
 
    }
}