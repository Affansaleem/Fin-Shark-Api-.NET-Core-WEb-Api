using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interface;
using api.Mapper;
using FinShark.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
   
    public class StockRepository:IStockRepository
    {
         private readonly FinSharkDbContext _context;
        public StockRepository(FinSharkDbContext context)
        {
            _context=context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            
             await _context.Stocks.AddAsync(stockModel);
             await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var existingUser=await _context.Stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(existingUser == null)
            {
             return null;   
            }
             _context.Stocks.Remove(existingUser);
             await _context.SaveChangesAsync();
             return existingUser;
        }

        public Task<List<Stock>> GetAllasync()
        {
            return _context.Stocks.Include(s=>s.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(s=>s.Comments).FirstOrDefaultAsync(x=>x.Id==id);

        }

        public async Task<bool> StockExists(int id)
        {
            return await _context.Stocks.AnyAsync(x=>x.Id==id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto request)
        {
            var existingUser=await _context.Stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(existingUser == null)
            {
                return null;
            }
            existingUser.CompanyName=request.CompanyName;
            existingUser.Industry= request.Industry;
            existingUser.LastDiv=request.LastDiv;
            existingUser.MarketCap=request.MarketCap;
            existingUser.Purchase=request.Purchase;
            existingUser.Symbol=request.Symbol;
            await _context.SaveChangesAsync();

            return existingUser;
        }

        
    }
}