using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FoodLibrary.Models;

namespace FoodLibrary.Services
{
    public interface ILoadJsonService
    {

        Task<List<FoodInformation>> ReadJsonAsync();
    }
}
