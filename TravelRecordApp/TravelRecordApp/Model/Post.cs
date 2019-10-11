using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _experience;
        public string Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;
                OnPropertyChanged("Experience");
            }
        }

        private string _venueName;
        public string VenueName
        {
            get { return _venueName; }
            set
            {
                _venueName = value;
                OnPropertyChanged("VenueName");
            }
        }

        private string _categoryId;
        public string CategoryId
        {
            get { return _categoryId; }
            set
            {
                _categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private int _distance;
        public int Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged("Distance");
            }
        }


        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }


        private Venue _venue;
        [JsonIgnore]
        public Venue Venue
        {
            get { return _venue; }
            set
            {
                _venue = value;


                if (_venue.categories != null)
                {
                    var firstCategory = _venue.categories.FirstOrDefault();

                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;
                    }
                }


                if (_venue.location != null)
                {
                    Address = _venue.location.address;
                    Distance = _venue.location.distance;
                    Latitude = _venue.location.lat;
                    Longitude = _venue.location.lng;
                }


                VenueName = _venue.name;
                UserId = App.User.Id;

                OnPropertyChanged("Venue");
            }
        }

        private DateTimeOffset _createDate;

        public DateTimeOffset CreateDate
        {
            get { return _createDate; }
            set
            {
                _createDate = value; 
                OnPropertyChanged("CreateDate");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public static async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        public static async Task<List<Post>> Read()
        {
            return await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.User.Id).ToListAsync();
        }

        public static Dictionary<string, int> ReadPostCategories(List<Post> posts)
        {
            var categories = (from p in posts orderby p._categoryId select p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

            foreach (var category in categories)
            {
                var count = (from post in posts where post.CategoryName == category select post).ToList().Count;

                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }


    }
}
