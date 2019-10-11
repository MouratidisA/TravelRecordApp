using System;
using System.Linq;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel;

        public MainPage()
        {
            InitializeComponent();

            ViewModel = new MainViewModel();
            BindingContext = ViewModel;

            var assembly = typeof(MainPage);
            IconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }


    }
}
