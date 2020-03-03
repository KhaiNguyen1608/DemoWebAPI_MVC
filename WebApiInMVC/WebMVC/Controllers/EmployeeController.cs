using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using System.Net.Http;

namespace WebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> emplist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            emplist = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(emplist);
        }

    }
}