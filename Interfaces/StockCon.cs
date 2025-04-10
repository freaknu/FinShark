using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface StockCon
    {
        public Task<List<Stock>> GetStocksAsync(QueryObject query);
        public Task<Stock?> GetByidAsync(int StockId);
        public Task<Stock> CreateAsync(Stock stockModel);
        public Task<Stock?> DeleteStock(int StockId);
        public Task<bool> StockExists(int stockId);
    }
}