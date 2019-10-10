using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            #region SQLite Implementation
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    var postTable = conn.Table<Post>().ToList();

            //    var categories = (from p in postTable orderby p.CategoryId select p.CategoryName).Distinct().ToList();

            //    Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            //    foreach (var category in categories)
            //    {
            //        var count = (from post in postTable where post.CategoryName == category select post).ToList().Count;

            //        categoriesCount.Add(category, count);
            //    }

            //    CategoryListView.ItemsSource = categoriesCount;

            //    PostCountLabel.Text = postTable.Count.ToString();

            //}
            #endregion

            var postTable = await Post.Read();

            var categoriesCount = Post.ReadPostCategories(postTable);

            CategoryListView.ItemsSource = categoriesCount;

            PostCountLabel.Text = postTable.Count.ToString();
        }
    }
}