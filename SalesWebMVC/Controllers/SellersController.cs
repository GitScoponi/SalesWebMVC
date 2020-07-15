using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Services;
using SalesWebMVC.Models.Services.Exceptions;
using SalesWebMVC.Models.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.findAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentsService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentsService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Departments = departments, Seller = seller };
                return View(viewModel);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task< IActionResult> Delete(int? id)
        {
           
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
            
           

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegretyException e)
            {

                return Error(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var obj = await _sellerService.FindByIdAsync(id);
            return View(obj);
        }

        public async Task< IActionResult> Update(int? id)
        {
            var obj = await _sellerService.FindByIdAsync(id);
            if (id == null || obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            var department = await _departmentsService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = department };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentsService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Departments = departments, Seller = seller };
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));

            }
            catch (NotFoundException e)
            {

                return RedirectToAction(nameof(Error), e.Message);
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), e.Message);
            }
        }

        public IActionResult Error(string msg)
        {
            var viewModel = new ErrorViewModel
            {
                Message = msg,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View("Error",viewModel);
        }

    }
}