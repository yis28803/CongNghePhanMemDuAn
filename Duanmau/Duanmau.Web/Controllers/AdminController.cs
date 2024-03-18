using Duanmau.Web.API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;

namespace Duanmau.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdminController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> FoodAll()
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7152/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Food");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                List<Food> foods = JsonConvert.DeserializeObject<List<Food>>(responseContent);

                return View("FoodAll", foods);
                // Bây giờ bạn có thể sử dụng danh sách `foods` như bạn muốn
                // Ví dụ: Truyền danh sách foods đến view hoặc xử lý chúng theo cách khác
            }
            else
            {
                // Xử lý trường hợp không thành công
                return View("Error");
            }

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FoodCreate()
        {
            return View("FoodCreate");
        }

        public async Task<IActionResult> FoodSaveAsync(Food food)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7152/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Chuyển đối tượng food thành dữ liệu JSON
            string jsonFood = JsonConvert.SerializeObject(food);

            // Tạo nội dung yêu cầu từ dữ liệu JSON
            var content = new StringContent(jsonFood, Encoding.UTF8, "application/json");

            // Gửi yêu cầu POST đến API để lưu sản phẩm
            HttpResponseMessage response = await client.PostAsync("api/Food", content);

            if (response.IsSuccessStatusCode)
            {
                // Xử lý khi lưu sản phẩm thành công
                return RedirectToAction("FoodAll");
            }
            else
            {
                // Xử lý khi lưu sản phẩm không thành công
                return View("Error");
            }
        }


        public async Task<IActionResult> FoodEdit(int id)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7152/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync($"api/Food/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Food food = JsonConvert.DeserializeObject<Food>(responseContent);

                return View("FoodEdit", food);
            }
            else
            {
                // Xử lý trường hợp không thành công
                return View("Error");
            }
        }

        public async Task<IActionResult> FoodSaveEditedAsync(Food editedFood)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7152/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Chuyển đối tượng food chỉnh sửa thành dữ liệu JSON
            string jsonEditedFood = JsonConvert.SerializeObject(editedFood);

            // Tạo nội dung yêu cầu từ dữ liệu JSON
            var content = new StringContent(jsonEditedFood, Encoding.UTF8, "application/json");

            // Gửi yêu cầu POST đến API để cập nhật sản phẩm
            HttpResponseMessage response = await client.PutAsync($"api/Food/{editedFood.FoodId}", content);

            if (response.IsSuccessStatusCode)
            {
                // Xử lý khi cập nhật sản phẩm thành công
                return RedirectToAction("FoodAll");
            }
            else
            {
                // Xử lý khi cập nhật sản phẩm không thành công
                return View("Error");
            }
        }

        public async Task<IActionResult> FoodDeleteAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7152/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Gửi yêu cầu DELETE đến API để xóa sản phẩm
            HttpResponseMessage response = await client.DeleteAsync($"api/Food/{id}");

            if (response.IsSuccessStatusCode)
            {
                // Xử lý khi xóa sản phẩm thành công
                return RedirectToAction("FoodAll");
            }
            else
            {
                // Xử lý khi xóa sản phẩm không thành công
                return View("Error");
            }
        }



    }
}
