using System;
using System.Collections.Generic;
using System.Text;
using FoodLibrary.Services;
using GalaSoft.MvvmLight;

namespace FoodLibrary.ViewModels
{
    public class MenuPage2ViewModel:ViewModelBase
    {
        /// <summary>
        /// 历史记录服务。
        /// </summary>
        private IHistoryService _historyService;

        public MenuPage2ViewModel(IHistoryService historyService)
        {
            _historyService = historyService;
        }
    }
}
