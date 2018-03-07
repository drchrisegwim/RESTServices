using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCEndPointConsumer.Models;
using Newtonsoft.Json;

namespace MVCEndPointConsumer.Controllers
{
    public class HomeController : Controller
    {
        // Hosted web API REST Service base url

        private readonly string BaseUrl = "http://localhost:8801/";
        public async Task<ActionResult> Index()
        {
            List<Employee> EmpInfo = new List<Employee>();

            using (var client = new HttpClient())
            {
                
                //passng service base url
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web API REST service resource GetAllEmployee using HttpClient

                HttpResponseMessage Res = await client.GetAsync("api/home/GetEmpDetails");

                //Cheking the response is successful or not which is sent using HttpClient

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api

                    var empResponse = Res.Content.ReadAsStringAsync().Result;

                    EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(empResponse);
                }


            }
            return View(EmpInfo);
        }
    }
}