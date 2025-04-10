using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class StockRequestDTO
    {
        [Required]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000)]
        public decimal Purchase { get; set; }
        [MaybeNull]
        public decimal Divident { get; set; }
        [Required]
        public string Industry { get; set; } = string.Empty;
        [MaybeNull]
        public long MarketCap { get; set; }
    }
}