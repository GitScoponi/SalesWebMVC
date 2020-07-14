using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Services;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentsService;

        public SellersController(SellerService sellerService, DepartmentService departmentsService)
        {
            _sellerService = sellerService;
            _departmentsService = departmentsService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.findAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentsService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var obj = _sellerService.FindById(id);
            return View(obj);
        }
    }
}