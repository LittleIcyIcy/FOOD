using FoodLibrary.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using FoodLibrary.Models;

namespace FoodLibrary.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
        /// <summary>
        /// 位置服务。
        /// </summary>
        private ILocationService _locationService;

        /// <summary>
        /// 天气服务。
        /// </summary>
        private IWeatherService _weatherService;
        
        /// <summary>
        /// 推荐服务。
        /// </summary>
        private IRecommendationService _recommendationService;

        /// <summary>
        /// 所有的天气数据。
        /// </summary>
        private WeatherRoot _weatherRootData;

        /// <summary>
        /// 温度。
        /// </summary>
        public string Temperature
        {
            get =>_temperature;
            set => Set(nameof(Temperature), ref _temperature, value);
        }
        private string _temperature;

        /// <summary>
        /// 湿度。
        /// </summary>
        public string Humidity
        {
            get => _humidity;
            set => Set(nameof(Humidity), ref _humidity, value);
        }
        private string _humidity;

        /// <summary>
        /// 天气状态。
        /// </summary>
        public string Description;

        /// <summary>
        /// 位置。
        /// </summary>
        public string Site
        {
            get => _site;
            set => Set(nameof(Site), ref _site, value);
        }
        private string _site;

        public MainPageViewModel(ILocationService locationService,
            IWeatherService weatherService,IRecommendationService recommendationService)
        {
            _locationService = locationService;
            _weatherService = weatherService;
            _recommendationService = recommendationService;
        }

        public Weather WeatherRoot;

        /// <summary>
        /// 绑定到刷新天气的按钮。
        /// </summary>
        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand
            = new RelayCommand(async () =>
            {
                _weatherRootData = await _weatherService.GetWeatherAsync();
                Temperature = _weatherRootData.main.temp + "℃";
                Humidity = _weatherRootData.main.humidity;
                Site = _weatherRootData.sys.country;
            }));

        /// <summary>
        /// 获得所推荐的菜品的名称列表。
        /// </summary>
        public RelayCommand RecommendationCommand =>
            _recommendationCommand ?? (_recommendationCommand
                = new RelayCommand(async () =>
                {
                    FoodNameCollection.Clear();
                    FoodNameCollection.AddRange(await _recommendationService.ReFlashAsync());
                }));
        private RelayCommand _recommendationCommand;

        /// <summary>
        /// 绑定到listview。
        /// </summary>
        public ObservableRangeCollection<FoodInformation> FoodNameCollection { get; } =
            new ObservableRangeCollection<FoodInformation>();
    }
}
