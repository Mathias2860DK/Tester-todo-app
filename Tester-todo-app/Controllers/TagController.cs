using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tester_todo_app.Data;
using Tester_todo_app.DTOs;
using Tester_todo_app.Entities;

namespace Tester_todo_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TagController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDTO>>> GetAllTags()
        {
            var tags = await _dataContext.Tags
                .Select(tag => new TagDTO
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Description = tag.Description
                })
                .ToListAsync();

            return Ok(tags);
        }

    }
}
