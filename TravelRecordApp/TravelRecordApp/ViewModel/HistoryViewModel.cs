using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        public async Task<bool> UpdatePosts()
        {

            try
            {
                var posts = await Post.Read();
                if (posts != null)
                {
                    Posts.Clear();
                    foreach (var post in posts)
                        Posts.Add(post);
                }

                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public async void DeletePost(Post post)
        {
            await Post.Delete(post);
        }
    }

}
