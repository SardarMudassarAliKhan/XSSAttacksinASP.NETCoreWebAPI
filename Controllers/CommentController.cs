using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using XSSAttacksinASP.NETCoreWebAPI.Models;

namespace XSSAttacksinASP.NETCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly HtmlSanitizer _sanitizer;

        public CommentController()
        {
            _sanitizer = new HtmlSanitizer();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comment.Content = _sanitizer.Sanitize(comment.Content);
            comment.CreatedAt = DateTime.UtcNow;

            return Ok(new { Message = "Comment created successfully!", SanitizedContent = comment.Content });
        }
    }
}