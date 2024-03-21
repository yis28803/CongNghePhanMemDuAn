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
        
        public IActionResult Index()
        {
            return View();
        }

    }
}
