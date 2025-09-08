using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Products>> ListAsync();
        Task<Products?> GetByIdAsync(int id);
        Task AddAsync(Products entity);
        Task UpdateAsync(Products entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
