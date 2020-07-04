using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public Department()
        {
        }

        public Department(string nome)
        {
            Nome = nome;
        }

        public Department(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public void addSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double totalSales(DateTime init, DateTime final)
        {
            return Sellers.Sum(x => x.totalSales(init,final));
        }
    }
}
