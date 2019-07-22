using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FoodLibrary.ViewModels;
using System.ServiceModel.Channels;
using ChooseFood.View;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ChooseFood
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 当前页。
        /// </summary>
        private Type currentPage;

        private readonly IList<(string Tag, Type Page)> _pages =
            new List<(string Tag, Type Page)>
            {
                ("MenuPage1", typeof(MainPage)),
                ("MenuPage2", typeof(MenuPage2)),
                ("MenuPage3", typeof(MenuPage3)),
                ("MenuPage4", typeof(MenuPage4))
            };

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args) {
            throw new NotImplementedException();
        }
    }
}
