using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mphil.WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<WeatherItem> WeatherItems { get; private set; }
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.oceandrivers.com/v1.0/getWebCams/");
                if (response.IsSuccessStatusCode)
                {
                    WeatherItems = new ObservableCollection<WeatherItem>();
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<WeatherItem>>(content);

                    foreach (var item in data)
                    {
                        WeatherItems.Add(item);
                    }
                }
            }

            BindingContext = this;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            WeatherItem tappedItem = e.Item as WeatherItem;
            Navigation.PushAsync(new DetailsPage(tappedItem));
        }
    }
}
