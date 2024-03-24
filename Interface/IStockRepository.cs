using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using FinShark.Models;

namespace api.Interface
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllasync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync (Stock stockModel);
        Task<Stock?> UpdateAsync (int id, UpdateStockRequestDto request );
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
    }
}