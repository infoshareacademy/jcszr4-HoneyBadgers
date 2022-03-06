using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using Newtonsoft.Json;

namespace HoneyBadgers.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IHttpClientFactory _iHttpClientFactory;
        public ReportController(IHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }
        [HttpGet]
        public async Task<ActionResult<Report>> Index()
        {
            var client = _iHttpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/reports");

            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch(Exception ex)
            {
                return View(new Report[]{ new Report(ex.Message) });
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Report[]>(content); ;
            return View(json);
        }

        [HttpGet]
        public async Task<ActionResult> GenreReport()
        {
            var expenses = new List<Tuple<string, int>>();
            expenses.Add(new Tuple<string, int>("Book", 3));
            expenses.Add(new Tuple<string, int>("Horror", 8));
            expenses.Add(new Tuple<string, int>("Fantasy", 6));
            expenses.Add(new Tuple<string, int>("Bookf", 1));

            ViewBag.Ex = expenses;
            return View();
        }

        [HttpPost]
        public JsonResult NewChart()
        {
            var strEducation = "Book";
            var educationValue = Math.Round(34.6, 0);

            List<object> iData = new List<object>();
            //Creating sample data    
            DataTable dt = new DataTable();
            dt.Columns.Add("Expense", System.Type.GetType("System.String"));
            dt.Columns.Add("ExpenseValues", System.Type.GetType("System.Int32"));

            //For Education  
            DataRow dr = dt.NewRow();
            dr["Expense"] = strEducation;
            dr["ExpenseValues"] = educationValue;
            dt.Rows.Add(dr);

            //Looping and extracting each DataColumn to List<Object>    
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            ViewBag.ChartData = iData;
            //Source data returned as JSON    
            return Json(iData);
        }
    }
}
