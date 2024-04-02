using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tester_todo_app.Data;
using Tester_todo_app.Entities;

namespace Tester_todo_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TodoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllTodos()
        {
            var todos = await _dataContext.Todos.ToListAsync();
            return Ok(todos);
        }

        [HttpPut]
        public async Task<ActionResult<Todo>> UpdateTodo(Todo todo)
        {
            var todoToBeUpdated = await _dataContext.Todos.FindAsync(todo.Id);
            if (todoToBeUpdated == null)
            {
                return NotFound("No todo found");
            }
            todoToBeUpdated.IsCompleted = !todo.IsCompleted;
            _dataContext.Todos.Update(todoToBeUpdated);
            await _dataContext.SaveChangesAsync();
            return Ok(todoToBeUpdated);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> AddTodo(Todo todo)
        {
            
            if (todo == null)
            {
                return NotFound("No todo found");
            }
            _dataContext.Todos.Update(todo);
            await _dataContext.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            var todoToBeDeleted = await _dataContext.Todos.FindAsync(id);
            if (todoToBeDeleted == null)
            {
                return NotFound("Hero not found");
            }
            _dataContext.Todos.Remove(todoToBeDeleted);
            await _dataContext.SaveChangesAsync();
            return Ok("All good");
        }
    }
}
