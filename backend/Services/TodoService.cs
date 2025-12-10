using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class TodoService
    {
        private readonly UsmDb _db;

        public TodoService(UsmDb db)
        {
            _db = db;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _db.Todos.ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _db.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateAsync(Todo todo)
        {
            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo?> UpdateAsync(int id, Todo data)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null) return null;

            todo.Title = data.Title;
            todo.IsDone = data.IsDone;

            await _db.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await _db.Todos.FindAsync(id);
            if (todo == null) return false;

            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
