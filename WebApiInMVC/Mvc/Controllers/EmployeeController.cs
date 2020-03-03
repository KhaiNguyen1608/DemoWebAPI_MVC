using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        /*public ActionResult Index()
        {

            IEnumerable<mvcEmployeeModel> empList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44381/api/");//The port of your project in IIS Express.
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("Employee");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<mvcEmployeeModel>>();
                    readTask.Wait();
                    empList = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    empList = Enumerable.Empty<mvcEmployeeModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            //IEnumerable<mvcEmployeeModel> empList;
            // HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;
            // empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(empList);
        }*/
        public ActionResult Index(string search)
        {

            IEnumerable<mvcEmployeeModel> empList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44381/");//The port of your project in IIS Express.
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("api/Employee/" + search);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<mvcEmployeeModel>>();
                    readTask.Wait();
                    empList = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    empList = Enumerable.Empty<mvcEmployeeModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            // HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;
            //empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(empList);
        }


        // POST: Employee
        [HttpPost]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcEmployeeModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel emp)
        {
            if (emp.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employee/" + emp.EmployeeID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}