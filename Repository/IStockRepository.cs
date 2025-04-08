using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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
            return await context.Stock.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByidAsync(int StockId)
        {
            var stock = await context.Stock.FirstOrDefaultAsync(st => st.Id == StockId);
            return stock;
        }

        public async Task<Stock?> DeleteStock(int StockId)
        {
            var stock = await GetByidAsync(StockId);
            if (stock == null) return new Stock();
            context.Stock.Remove(stock);
            await context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await context.AddAsync(stockModel);
            await context.SaveChangesAsync();
            return stockModel;
        }
    }
}