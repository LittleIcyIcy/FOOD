using ChooseFood.Services.Impl;
using FoodLibrary.Services;
using FoodLibrary.Services.Impl;
using FoodLibrary.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using FoodLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseFood
{
    public class ViewModelLocator
    {
        public MainPageViewModel MainPageViewModel =>
            SimpleIoc.Default.GetInstance<MainPageViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<ILocationService, LocationService>();
            SimpleIoc.Default.Register<IWeatherService, WeatherService>();
            SimpleIoc.Default.Register<IRecommendationService, RecommendationService>();
            SimpleIoc.Default.Register<ILoadJsonService, LoadJsonService>();
            SimpleIoc.Default.Register<MainPageViewModel>();
        }
    }
}
