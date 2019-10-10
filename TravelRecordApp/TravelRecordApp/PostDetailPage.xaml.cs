using SQLite;
using System;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        private Post selectedPost;

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            ExperienceEntry.Text = selectedPost.Experience;
            VenueLabel.Text = selectedPost.VenueName;
            CategoryLabel.Text = selectedPost.CategoryName;
            AddressLabel.Text = selectedPost.Address;
            CoordinatesLabel.Text = $"{selectedPost.Latitude}, {selectedPost.Longitude}";
            DistanceLabel.Text = $"{selectedPost.Distance} m";


        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = ExperienceEntry.Text;

            #region SQLite Implementation
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    int rows = conn.Update(selectedPost);

            //    if (rows > 0)
            //        DisplayAlert("Success", "Experience successfully updated", "Ok");
            //    else
            //        DisplayAlert("Failure", "Experience failed to be updated", "Ok");
            //}
            #endregion

            try
            {
                await App.MobileService.GetTable<Post>().UpdateAsync(selectedPost);
                await DisplayAlert("Success", "Experience successfully updated", "Ok");
            }
            catch (Exception)
            {
                await DisplayAlert("Failure", "Experience failed to be updated", "Ok");
            }


        }
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            #region SQLite Implementation
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    int rows = conn.Delete(selectedPost);

            //    if (rows > 0)
            //        DisplayAlert("Success", "Experience successfully deleted", "Ok");
            //    else
            //        DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
            //}
            #endregion

            try
            {
                await App.MobileService.GetTable<Post>().DeleteAsync(selectedPost);
                await DisplayAlert("Success", "Experience successfully deleted", "Ok");
            }
            catch (Exception)
            {

                await DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
            }

        }
    }
}