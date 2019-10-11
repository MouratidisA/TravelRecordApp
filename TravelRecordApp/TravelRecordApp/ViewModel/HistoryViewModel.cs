using System.Collections.ObjectModel;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel
{
    public class HistoryViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }

        public HistoryViewModel()
        {
            Posts = new ObservableCollection<Post>();
        }

        public async void UpdatePosts()
        {


            var posts = await Post.Read();
            if (posts != null)
            {
                Posts.Clear();
                foreach (var post in posts)
                    Posts.Add(post);
            }
        }
    }

}
