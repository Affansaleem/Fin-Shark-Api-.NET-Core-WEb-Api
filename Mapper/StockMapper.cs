using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Stock;
using api.Dtos.Stock;
using FinShark.Models;

namespace api.Mapper
{
    public static class StockMapper
    {
        public static StockDtoModel ToStockDto(this Stock stock)
        {
            return new StockDtoModel
            {
                Id=stock.Id,
                CompanyName=stock.CompanyName,
                Industry=stock.Industry,
                LastDiv=stock.LastDiv,
                MarketCap=stock.MarketCap,
                Purchase=stock.Purchase,
                Symbol=stock.Symbol,
            };
        }
        public static Stock ToStockFromDto(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                CompanyName=stockDto.CompanyName,
                Industry=stockDto.Industry,
                LastDiv=stockDto.LastDiv,
                MarketCap=stockDto.MarketCap,
                Purchase=stockDto.Purchase,
                Symbol=stockDto.Symbol,
            };
        }
    }
}