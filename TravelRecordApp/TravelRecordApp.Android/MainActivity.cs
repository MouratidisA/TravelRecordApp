using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using Plugin.Permissions;
using Environment = System.Environment;

namespace TravelRecordApp.Droid
{
    [Activity(Label = "TravelRecordApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("FastRenders_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.FormsMaps.Init(this, savedInstanceState);
            CurrentPlatform.Init();

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this ,savedInstanceState);

            string dbName = "travel_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string fullPath = System.IO.Path.Combine(folderPath, dbName);


            LoadApplication(new App(fullPath));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode,permissions,grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}