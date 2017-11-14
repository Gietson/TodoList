using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DTO;

namespace TodoList.Services
{
    public interface ITodoService : IService
    {
        Task<TodoDto> AddAsync(TodoDto todo);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task<List<TodoDto>> GetAllAsync();
        Task<TodoDto> GetAsync(Guid id);
    }
}
