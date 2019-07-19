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

        public MenuPage2ViewModel MenuPage2ViewModel =>
            SimpleIoc.Default.GetInstance<MenuPage2ViewModel>();

        public MenuPage3ViewModel MenuPage3ViewModel =>
            SimpleIoc.Default.GetInstance<MenuPage3ViewModel>();

        public MenuPage4ViewModel MenuPage4ViewModel =>
            SimpleIoc.Default.GetInstance<MenuPage4ViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<ILocationService, LocationService>();
            SimpleIoc.Default.Register<IWeatherService, WeatherService>();
            SimpleIoc.Default.Register<IRecommendationService, RecommendationService>();
            SimpleIoc.Default.Register<ILoadJsonService, LoadJsonService>();
            SimpleIoc.Default.Register<IHistoryService,HistoryService>();
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<MenuPage2ViewModel>();
            SimpleIoc.Default.Register<MenuPage3ViewModel>();
            SimpleIoc.Default.Register<MenuPage4ViewModel>();
        }
    }
}
