using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class EfProductRepository : IProductRepository
    {
        private readonly Data.MvcProductContext _db;

        public EfProductRepository(Data.MvcProductContext db) => _db = db;

        public async Task<List<Products>> ListAsync() =>
            await _db.Products.AsNoTracking().ToListAsync();

        public async Task<Products?> GetByIdAsync(int id) =>
            await _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Products entity)
        {
            _db.Products.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Products entity)
        {
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var found = await _db.Products.FindAsync(id);
            if (found != null)
            {
                _db.Products.Remove(found);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _db.Products.AnyAsync(p => p.Id == id);
    }
}