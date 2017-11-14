using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Repositories
{
    public interface ITodoRepository : IRepository, IMongoRepository
    {
        Task AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task RemoveAsync(Todo todo);
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetAsync(Guid id);
    }
    
}
