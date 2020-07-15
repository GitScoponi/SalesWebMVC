using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public Seller()
        {
        }

        public Seller(string nome, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Nome = nome;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public Seller(int id, string nome, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Nome = nome;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage ="{0} required")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="{0} size should be between {2} and {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage ="{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [Range(100.0,50000.0,ErrorMessage ="{0} must be from {1} and {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public void addSales(SalesRecord sales)
        {
            Sales.Add(sales);
        }
        public void removeSales(SalesRecord sales)
        {
            Sales.Remove(sales);
        }
        public double totalSales(DateTime init, DateTime final)
        {
            return Sales.Where(x => x.Date >= init && x.Date <= final).Sum(x => x.Amount);
        }
        
    }
}
  
