using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickParcel.Models;
using System.Text;

namespace QuickParcel.Controllers
{
    public class ProductsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7295/api");
        private readonly HttpClient _httpClient;

        public ProductsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        //HttpGET
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Products/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(data);
            }
            return View(products);
        }
        public IActionResult Details(int? id)
        {
            Product product = new Product();
            if (id == null) { return NotFound(); }
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Products/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(data);
            }
            return View(product);
        }
        public IActionResult Create(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent stringContent = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Products/",stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
         



        public IActionResult Edit(int? id)
        {

            Product product = new Product();
            if (id == null) { return NotFound(); }
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Products/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(data);
            }
            return View(product);



        }
        //HttpPut{id}
        [HttpPost]
        public IActionResult Edit(int? id,Product product)
        {
            string data = JsonConvert.SerializeObject(product);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Products/" + id, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            Product product = new Product();
            //if (id == null) { return NotFound(); }
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Products/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(data);
            }
            return View(product);
        }
        //HttpDelete{id}
        [HttpPost(), ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Products/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
