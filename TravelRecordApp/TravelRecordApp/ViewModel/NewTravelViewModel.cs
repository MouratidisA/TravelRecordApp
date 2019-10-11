using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelViewModel :INotifyPropertyChanged
    {
        public PostCommand PostCommand { get; set; }
        
        private Post _post { get; set; }        
        public Post Post
        {
            get { return _post; }
            set
            {
                _post = value;
                OnPropertyChanged("Post");
            }
        }


        private string _experience;
        public string Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;
                Post=new Post(){Experience = this.Experience,Venue = this.Venue};
                OnPropertyChanged("Experience");
            }
        }


        private Venue _venue;
        public Venue Venue
        {
            get { return _venue; }
            set
            {
                _venue = value;
                Post = new Post() { Experience = this.Experience, Venue = this.Venue };
                OnPropertyChanged("Venue");
            }
        }



        public NewTravelViewModel()
        {
            PostCommand = new PostCommand(this);             
            Post = new Post();
            Venue= new Venue();
        }


        public async void PublishPost(Post post)
        {
            try
            {

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
                await App.Current.MainPage.DisplayAlert("Success", "Experience successfully inserted", "Ok");
            }
            catch (NullReferenceException nllEx)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted" + nllEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted" + ex.Message, "Ok");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
