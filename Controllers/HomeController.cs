using ManiWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace ManiWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppConfig _config;
        public HomeController(ILogger<HomeController> logger, IOptions<AppConfig> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmployeeModel employee)
        {
            
            string apiUrl = _config.WebApiURL;

            _logger.LogInformation($"calling API:{apiUrl}");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                var jsonContent = JsonConvert.SerializeObject(employee);
                var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("employee", UriKind.Relative),
                    Content = data
                };

                HttpResponseMessage response = await client.SendAsync(httpRequest);
                if (response.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Data saved successfully";
                }
                else
                {
                    ViewData["Message"] = "Unable to save";
                }
            }
            return View();

        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}