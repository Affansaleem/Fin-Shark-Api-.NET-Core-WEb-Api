using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
       public CommentController(ICommentRepository commentRepository,IStockRepository stockRepository)
       {
            _commentRepository=commentRepository;
            _stockRepository=stockRepository;
       }

       [HttpGet]
       public async Task<IActionResult> GetAll()
       {
            var commentsModel= await _commentRepository.GetAllAsync();
            var commentsDto= commentsModel.Select(s=>s.ToCommentDto());
            return Ok(commentsDto);
       }

       [HttpGet]
       [Route("{id}")]
       public async Task<IActionResult> GetById([FromRoute] int id)
       {
            var commentModel= await _commentRepository.GetByIdASync(id);

            if(commentModel == null)
            {
                return NotFound();
            }
            return Ok(commentModel.ToCommentDto());
       }
       [HttpPost]
       [Route("{id}")]
       public async Task<IActionResult> Create([FromBody] CreateCommentDto createCommentDto, [FromRoute] int id)
       {
          if(!await _stockRepository.StockExists(id))
          {
               return BadRequest();
          }
          var commentModel= createCommentDto.ToCommentFromDto(id);
          var comment=await _commentRepository.CreateAsync(commentModel);
          var commentModelDto= comment.ToCommentDto();
          return CreatedAtAction(nameof(GetById),new {id = commentModelDto.Id}, commentModelDto);
          // _commentRepository.CreateAsync(createCommentDto,id);
       }

       [HttpDelete]
       [Route("{id}")]
       public async Task<IActionResult> Delete([FromRoute] int id)
       {
          var commentModel=await _commentRepository.DeleteAsync(id);
          if(commentModel == null)
          {
               return NotFound("No record found!");
          }
          return Ok(commentModel.ToCommentDto());
       }
       
    }
}