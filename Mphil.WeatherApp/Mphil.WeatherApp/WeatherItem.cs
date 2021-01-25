using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mphil.WeatherApp
{
    public class WeatherItem : INotifyPropertyChanged
    {
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string url { get; set; }
        public string location => $"Latitude:{latitude}, Longtitue: {longitude}";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
