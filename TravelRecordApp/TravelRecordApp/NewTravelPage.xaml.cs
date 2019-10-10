using Plugin.Geolocator;
using System;
using System.Linq;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        private Post post;

        public NewTravelPage()
        {
            InitializeComponent();
            post = new Post();
            ContainerStackLayout.BindingContext = post;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);


            VenueListView.ItemsSource = venues;

        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = VenueListView.SelectedItem as Venue;

                if (selectedVenue != null)
                {
                    post.CategoryId = selectedVenue.categories.FirstOrDefault()?.id;
                    post.CategoryName = selectedVenue.categories.FirstOrDefault()?.name;
                    post.Address = selectedVenue.location.address;
                    post.Distance = selectedVenue.location.distance;
                    post.Latitude = selectedVenue.location.lat;
                    post.Longitude = selectedVenue.location.lng;
                    post.VenueName = selectedVenue.name;
                    post.UserId = App.User.Id;
                }

                #region SQLite Implementation
                //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                //{
                //    conn.CreateTable<Post>();
                //    int rows = conn.Insert(post);

                //    if (rows > 0)
                //        DisplayAlert("Success", "Experience successfully inserted", "Ok");
                //    else
                //        DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
                //}
                #endregion

                Post.Insert(post);
                await DisplayAlert("Success", "Experience successfully inserted", "Ok");
            }
            catch (NullReferenceException nllEx)
            {
                await DisplayAlert("Failure", "Experience failed to be inserted" + nllEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failure", "Experience failed to be inserted" + ex.Message, "Ok");
            }

        }
    }
}