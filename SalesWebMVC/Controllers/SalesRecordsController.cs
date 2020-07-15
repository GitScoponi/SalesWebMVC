using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordsService _salesService;

        public SalesRecordsController(SalesRecordsService salesService)
        {
            _salesService = salesService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult > SimpleSearch(DateTime? minDate,DateTime? maxDate)
        {
            if(minDate==null)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (maxDate == null)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minData"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxData"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}