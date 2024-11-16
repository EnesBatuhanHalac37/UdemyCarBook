using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        [HttpGet("GetCommand")]
        public IActionResult GetCommand(int id)
        {
            var value = _repository.GetById(id);
            return Ok(value);

        }

        [HttpPost]
        public IActionResult CreateCommand(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Yorum Başarı İle Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveCommand(int id )
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Yorum Başarı İle Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCommand(Comment commend)
        {
            _repository.Update(commend);
            return Ok("Yorum Başarı ile Düzenlendi");
        }
      
    }
}
