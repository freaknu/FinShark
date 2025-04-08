using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDtos ToStockDto(this Stock stockmodel)
        {
            return new StockDtos
            {
                Id = stockmodel.Id,
                Symbol = stockmodel.Symbol,
                CompanyName = stockmodel.CompanyName,
                Purchase = stockmodel.Purchase,
                Industry = stockmodel.Industry,
                Comments = stockmodel.Comments.Select(com => com).ToList()
            };
        }
    }
}