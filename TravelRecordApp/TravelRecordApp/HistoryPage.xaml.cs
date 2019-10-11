using System;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        private HistoryViewModel ViewModel;

        public HistoryPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            #region SQLite Implementation
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    var posts = conn.Table<Post>().ToList();
            //    PostListView.ItemsSource = posts;
            //}
            #endregion


            ViewModel.UpdatePosts();
        }

        void Handle_ItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = PostListView.SelectedItem as Post;

            if (selectedPost != null)
                Navigation.PushAsync(new PostDetailPage(selectedPost));
        }

        //TODO implement [DeleteMenuItem_Clicked] action inside ICommand
        private void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            var post = ((MenuItem)sender).CommandParameter;
            ViewModel.DeletePost((Post)post);

            ViewModel.UpdatePosts();
        }
        //TODO implement [PostListView_OnRefreshing] action inside ICommand
        private async void PostListView_OnRefreshing(object sender, EventArgs e)
        {
            await ViewModel.UpdatePosts();
            PostListView.IsRefreshing = false;
        }
    }
}