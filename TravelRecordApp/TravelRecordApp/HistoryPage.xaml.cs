using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
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

            var posts = await Post.Read();
            PostListView.ItemsSource = posts;
        }

        void Handle_ItemSelected(Object sender,SelectedItemChangedEventArgs e)
        {
            var selectedPost = PostListView.SelectedItem as Post;

            if (selectedPost != null)
                Navigation.PushAsync(new PostDetailPage(selectedPost));
        }
    }
}