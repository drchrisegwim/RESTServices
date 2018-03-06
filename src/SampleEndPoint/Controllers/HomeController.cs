using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleEndPoint.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public bool AddEmpDetails()
        {
            return true;
        }

        [HttpGet]
        public string GetEmpDetails()
        {
            return "Christian Egwim";
        }

        [HttpDelete]
        public string DeleteEmpDetails(string id)
        {
            return "Employ detail have been deleted having " + id;
        }

        [HttpPut]

        public string UpdateEmpDetails(string name, string id)
        {
            return "Employee Detail Updated with " + name + "and Id " + id;
        }
    }
}
