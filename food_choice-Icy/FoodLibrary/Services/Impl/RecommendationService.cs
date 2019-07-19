using System;
using System.Collections.Generic;
using System.Text;
using FoodLibrary.Models;

namespace FoodLibrary.Services.Impl
{
    public class RecommendationService:IRecommendationService
    {
        private IWeatherService _weatherService;
        private ILoadJsonService _loadJsonService;
        List<FoodInformation> food_infs = null;
        public RecommendationService(IWeatherService weatherService, ILoadJsonService loadJsonService)
        {
            _weatherService = weatherService;
            _loadJsonService = loadJsonService;
        }
        

        public async System.Threading.Tasks.Task<List<FoodInformation>> ReFlashAsync()
        {
            food_infs = await _loadJsonService.ReadJsonAsync();
            int len = food_infs.Capacity;
            WeatherRoot data = await _weatherService.GetWeatherAsync();
            double tep = double.Parse(data.main.temp);
            int flag = -1;
            // 转换当地的天气状态
            if (tep > 30)
            {
                flag = 3;
            }
            else if (tep < 0)
            {
                flag = 1;
            }
            else
            {
                flag = 2;
            }
            int[] arr = new int[2];
            int cnt = 0;
            while (cnt < 2)
            {
                int get_num = getOneFoodNum(flag);
                if (Array.IndexOf(arr, get_num) != -1)
                {
                    continue;
                }
                arr.SetValue(get_num, cnt++);
            }
            List<FoodInformation> get_food_name = new List<FoodInformation>();
            for (int i = 0; i < cnt; i++)
            {
                get_food_name.Add(food_infs[arr[i]]);
            }
            return get_food_name;
        }
        private int getOneFoodNum(int statue)
        {
            int sum = 0;
            int[] arr = new int[food_infs.Count];
            for (int i = 0; i < food_infs.Count; i++)
            {
                arr[i] = food_infs[i].weight[statue - 1];
                sum += arr[i];
            }
            int number_rand = rand(sum);
            Console.WriteLine("number_rand = " + number_rand);

            int sum_temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum_temp += arr[i];
                if (number_rand <= sum_temp)
                {
                    return i;
                }
            }
            return -1;
        }
        private int rand(int n)
        {
            Random rd = new Random();
            return rd.Next(0, n);
        }
    }
}
