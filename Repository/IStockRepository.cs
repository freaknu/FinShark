using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public async Task<List<Stock>> GetStocksAsync(QueryObject query)
        {
            var stocks = context.Stock.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
                stocks = stocks.Where(st => st.CompanyName == query.CompanyName);

            if (!string.IsNullOrWhiteSpace(query.Symbol))
                stocks = stocks.Where(st => st.Symbol == query.Symbol);

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy == "Symbol")
                {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(st => st.Symbol) : stocks.OrderBy(st => st.Symbol);
                }
            }
            var skipnumbers = (query.PageNumber - 1) * query.PageSize;
            return await stocks.Skip(skipnumbers).Take(query.PageSize).ToListAsync();
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

        public async Task<bool> StockExists(int stockId)
        {
            var stock = context.Stock.FirstOrDefault(st => st.Id == stockId);
            if (stock == null) return false;
            return true;
        }

        internal async Task GetAll(QueryObject query)
        {
            throw new NotImplementedException();
        }
    }
}