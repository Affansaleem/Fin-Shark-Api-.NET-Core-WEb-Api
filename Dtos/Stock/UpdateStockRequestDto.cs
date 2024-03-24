using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public string LastDiv { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}