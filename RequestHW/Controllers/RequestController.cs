using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RequestHW.Models;

namespace RequestHW.Controllers
{
    public class RequestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<JsonPlaceholderModel> olist = new List<JsonPlaceholderModel>();
            using(var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/photos");
                var response = await client.GetAsync("photos");
                if (response.IsSuccessStatusCode)
                {
                    var readTask = await response.Content.ReadAsStringAsync();
                    olist = JsonConvert.DeserializeObject<List<JsonPlaceholderModel>>(readTask);
                }
            }
            return View(olist);
        }

        //public async Task<IActionResult> Index()
        //{
        //    List<Ogrenci> olist = new List<Ogrenci>();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7254/api/Ogranci/ListOgrenci/ListOgrenci");
        //        var response = await client.GetAsync("ListOgrenci");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var readTask = await response.Content.ReadAsStringAsync();

        //            olist = JsonConvert.DeserializeObject<List<Ogrenci>>(readTask);

        //        }
        //    }
        //    return View(olist);
        //}
    }
}
