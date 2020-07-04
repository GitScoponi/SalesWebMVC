using System;
using System.Collections.Generic;
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
        public string Nome { get; set; }
        public string  Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
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
        public double totalSales(DateTime init,DateTime final)
        {
            return Sales.Where(x => x.Date >= init && x.Date <= final).Sum(x => x.Amount);
        }
    }
}
