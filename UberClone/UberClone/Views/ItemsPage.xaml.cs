using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UberClone.Models;
using UberClone.Views;
using UberClone.ViewModels;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace UberClone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }
        

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void Refresh_Clicked(object sender, EventArgs e)
        {
            await GetLocation();
        }

        private async Task GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var postion = await locator.GetPositionAsync();
            var places = new List<Place>();
            places.Add(
                new Place()
                {
                    Position = new Xamarin.Forms.Maps.Position(postion.Latitude,postion.Longitude),
                    Address = "Test Address",
                    PlaceName = "Me"
                });
            MyMap.ItemsSource = places;
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(postion.Latitude, postion.Longitude),new Distance(20)));
        }
    }
}