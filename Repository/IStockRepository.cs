using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class IStockRepository : StockCon
    {
        private readonly ApplicationDBContext context;
        public IStockRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<List<Stock>> GetStocksAsync()
        {
            return await context.Stock.ToListAsync();
        }
    }
}