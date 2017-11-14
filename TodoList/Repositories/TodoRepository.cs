using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Todo> _todo => _database.GetCollection<Todo>("todo");

        public TodoRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Todo todo)
            => await _todo.InsertOneAsync(todo);

        public async Task UpdateAsync(Todo todo)
            => await _todo.ReplaceOneAsync(x => x.Id == todo.Id, todo);

        public async Task RemoveAsync(Todo todo)
            => await _todo.DeleteOneAsync(x => x.Id == todo.Id);

        public async Task<List<Todo>> GetAllAsync()
            => await _todo.AsQueryable().ToListAsync();

        public async Task<Todo> GetAsync(Guid id)
            => await _todo.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
    }
}
