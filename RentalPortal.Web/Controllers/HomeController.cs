using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentalPortal.Web.Common.Constants;
using RentalPortal.Web.Models;


namespace RentalPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _apiClient;
        //private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseString = await _apiClient.CreateClient().GetStringAsync($"{ApiRoutes.Equipment}/getequipment");
            var response = JsonConvert.DeserializeObject<List<EquipmentDto>>(responseString);
            return View(response);

        }


        public async Task<IActionResult> Details(int id)
        {
            var responseString = await _apiClient.CreateClient().GetStringAsync($"{ApiRoutes.Equipment}/GetEquipmentById/{id}");
            var response = JsonConvert.DeserializeObject<EquipmentDto>(responseString);

            var inventoryCount= await _apiClient.CreateClient().GetStringAsync($"{ApiRoutes.Equipment}/GetEquipmentCount/{id}");
            ViewBag.InventoryCount= JsonConvert.DeserializeObject<string>(inventoryCount);
            return View(response);

        }






    }
}
