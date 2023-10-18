using AkademiPlusMicroService.WebUI.DTOs.DiscountDTOs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace AkademiPlusMicroService.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5012/api/DiscountCoupon");
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var values = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDiscountCouponDTO>(jsonData);
            return View(values.data.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> CreateDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCouponDTO createDiscountCouponDTO)
        {
            createDiscountCouponDTO.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createDiscountCouponDTO.UserId = "string";
            var client = _httpClientFactory.CreateClient();
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(createDiscountCouponDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5012/api/DiscountCoupon", stringContent);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resoponseMessage = await client.DeleteAsync("http://localhost:5012/api/DiscountCoupon?id=" + id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5012/api/DiscountCoupon/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateDiscountCouponDTO>(jsonData);
            return View(values.data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountCouponDTO updateDiscountCouponDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(updateDiscountCouponDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5012/api/DiscountCoupon", stringContent);
            return RedirectToAction("Index");
        }
    }
}
