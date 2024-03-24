using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Comment;
using api.Dtos.Comment;
using FinShark.Models;

namespace api.Mapper
{
    public static class CommentMapper
    {
        public static CommentDtoModel ToCommentDto(this Comment comment)
        {
            return new CommentDtoModel
            {
                Id=comment.Id,
                Content=comment.Content,
                CreatedAt=comment.CreatedAt,
                Title=comment.Title,
                StockId= comment.StockId
            };
        }
        public static Comment ToCommentFromDto(this CreateCommentDto createCommentDto,int id)
        {
            return new Comment
            {
                Content=createCommentDto.Content,
                Title=createCommentDto.Title,
                StockId= id
            };
        }
    }
}