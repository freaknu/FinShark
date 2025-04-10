using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("/api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository stockRepo;
        public StockController(IStockRepository stockRepo)
        {
            this.stockRepo = stockRepo;
        }
        [HttpGet]
        public async Task<IActionResult> getAllStocks([FromQuery] QueryObject query)
        {
            try
            {
                var stocks = await stockRepo.GetStocksAsync(query);
                var st = stocks.Select((st, index) => st.ToStockDto());
                return Ok(st);
            }
            catch (Exception)
            {
                throw new Exception("Problem while Finding the stocks");
            }
        }

        //model binding extract the stock id into string and pass into the function as parameter
        [Route("/getbyid")]
        [HttpGet("{stockid}")]
        public async Task<IActionResult> getStockById([FromRoute] int stockid)
        {
            try
            {
                var stock = await stockRepo.GetByidAsync(stockid);
                if (stock == null)
                {
                    return NotFound();
                }
                return Ok(stock.ToStockDto());
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddData([FromBody] StockRequestDTO newstock)
        {
            try
            {
                var createStock = newstock.ToStockCreDTO();
                await stockRepo.CreateAsync(createStock);
                return CreatedAtAction(nameof(getStockById), new { stockid = createStock.Id }, createStock.ToStockDto());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("{stockid}")]
        public async Task<IActionResult> deleteStock([FromRoute] int stockid)
        {
            try
            {
                var stock = await stockRepo.DeleteStock(stockid);
                if (stock == null) return NotFound();
                return Ok("Deleted Successfully" + " " + stock);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}