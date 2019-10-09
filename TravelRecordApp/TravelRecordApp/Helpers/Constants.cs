using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp.Helpers
{
    public class Constants
    {
        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
        public const string CLIENT_ID = "[CLIENT ID] -- developer.foursquare.com";
        public const string CLIENT_SECRET = "[CLIENT SECRET] -- developer.foursquare.com";
    }
}
