﻿using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models.Services
{
    public class SellerService 
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> findAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById(int? id)
        {
            return _context.Seller.Include(x=>x.Department).Where(x => x.Id == id).FirstOrDefault();
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x=>x.Id == obj.Id)){
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();

            }
            catch (DbUpdateException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
