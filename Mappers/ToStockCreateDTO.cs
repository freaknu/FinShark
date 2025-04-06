using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class ToStockCreateDTO
    {
        public static Stock ToStockCreDTO(this StockRequestDTO stockdto)
        {
            return new Stock
            {
                Symbol = stockdto.Symbol,
                CompanyName = stockdto.CompanyName,
                Purchase = stockdto.Purchase,
                Industry = stockdto.Industry,
                MarketCap = stockdto.MarketCap,
                Divident = stockdto.Divident
            };
        }
    }
}