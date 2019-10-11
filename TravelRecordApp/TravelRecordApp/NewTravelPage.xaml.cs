using System.Linq;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        private NewTravelViewModel NewTravelViewModel;

        public NewTravelPage()
        {
            InitializeComponent();

            NewTravelViewModel = new NewTravelViewModel();
            BindingContext = NewTravelViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions
                        .Abstractions.Permission.Location))
                    {
                        await DisplayAlert("Need Permission", "We will have to access your location", "Ok");
                    }

                    var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

                    if (result.ContainsKey(Permission.Location))
                        status = result[Permission.Location];
                }


                if (status == PermissionStatus.Granted)
                {
                    var locator = CrossGeolocator.Current;
                    var position = await locator.GetPositionAsync();
                    var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
                    VenueListView.ItemsSource = venues;
                }
                else
                {
                    await DisplayAlert("No Permission", "You didn't granted permission to access your location, we cannot proceed", "Ok");
                }

            }
            catch (System.Exception)
            {

            }
        }
    }
}