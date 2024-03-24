using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly FinSharkDbContext _context;
        private readonly IStockRepository _stockRepository;
        public StockController(FinSharkDbContext context,IStockRepository stockRepository)
        {
            _context=context;
            _stockRepository=stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks= await _stockRepository.GetAllasync();
            var stockDto=stocks.Select(s=>s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock= await _stockRepository.GetByIdAsync(id);
            if(stock ==null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createStockRequestDto)
        {
            var stockModel=  createStockRequestDto.ToStockFromDto();
            stockModel=await _stockRepository.CreateAsync(stockModel);        
            // return Ok(stockModel);
            return CreatedAtAction(nameof(GetById),new {id=stockModel.Id},stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockRequestDto)
        {
            var stockModel= await _stockRepository.UpdateAsync(id,updateStockRequestDto);
            if(stockModel == null)
            {
                return NotFound();
            }
           
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel=await _stockRepository.DeleteAsync(id);
            if(stockModel == null)
            {
                return NotFound();
            }
            // return Ok(stockModel.ToStockDto());
            return NoContent();
        }
    }
}