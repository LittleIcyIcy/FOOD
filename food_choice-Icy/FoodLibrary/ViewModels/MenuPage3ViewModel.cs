using System;
using System.Collections.Generic;
using System.Text;
using FoodLibrary.Models;
using FoodLibrary.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmHelpers;

namespace FoodLibrary.ViewModels
{
    public class MenuPage3ViewModel:ViewModelBase {
        /// <summary>
        /// 读取所有菜品信息文件服务。
        /// </summary>
        private ILoadJsonService _loadJsonService;

        public MenuPage3ViewModel(ILoadJsonService loadJsonService)
        {
            _loadJsonService = loadJsonService;
        }

        /// <summary>
        /// 用于存储所有菜品的信息，跟listview进行绑定。
        /// </summary>
        public ObservableRangeCollection<FoodInformation> AllFoodInformationsCollection
            = new ObservableRangeCollection<FoodInformation>();

        /// <summary>
        /// 用于跟显示按钮绑定。
        /// </summary>
        private RelayCommand _showAllFoodInformationsCommand;
        public RelayCommand ShowAllFoodInformationsCommand => 
            _showAllFoodInformationsCommand ?? (_showAllFoodInformationsCommand = 
                new RelayCommand(async () => {
                    AllFoodInformationsCollection.Clear();
                    AllFoodInformationsCollection.AddRange(await _loadJsonService.ReadJsonAsync());
                }));
    }
}
