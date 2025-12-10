using backend.DTOs;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _service;

        public TodoController(TodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _service.GetByIdAsync(id);
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(TodoDto dto)
        {
            var todo = new Todo
            {
                Title = dto.Title,
                IsDone = dto.IsDone
            };

            await _service.CreateAsync(todo);

            return CreatedAtAction(nameof(GetAll), new { id = todo.Id }, todo);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Todo update)
        {
            var updated = await _service.UpdateAsync(id, update);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            return deleted
                ? Ok(new { message = $"Todo ID {id} deleted" })
                : NotFound(new { message = $"Todo ID {id} not found" });
        }
    }
}
