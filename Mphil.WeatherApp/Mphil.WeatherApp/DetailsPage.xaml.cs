using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mphil.WeatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public WeatherItem WeatherItem;

        public DetailsPage(WeatherItem weatherItem)
        {
            InitializeComponent();
            WeatherItem = weatherItem;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            image.Source =  WeatherItem.url;
            label.Text  = WeatherItem.name;
        }
    }
}