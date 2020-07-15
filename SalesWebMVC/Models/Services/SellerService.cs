using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Seller>> findAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Seller> FindById(int? id)
        {
            return await _context.Seller.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task RemoveAsync(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Seller obj)
        {
            bool hasId = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasId)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
