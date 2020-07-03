using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> DepartmentsCollections = new List<Department>();
            DepartmentsCollections.Add(new Department { Id = 1, Nome = "Recursos Humanos" });
            DepartmentsCollections.Add(new Department { Id = 2, Nome = "Contabilidade" });
            DepartmentsCollections.Add(new Department { Id = 3, Nome = "Deparatamento Pessoal" });
            return View(DepartmentsCollections);
        }
    }
}