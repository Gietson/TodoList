using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TodoList.Domain;
using TodoList.DTO;
using TodoList.Repositories;

namespace TodoList.Services
{
    public class TodoService : ITodoService
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<TodoDto> AddAsync(TodoDto todo)
        {
            Todo t = Todo.Create(Guid.NewGuid(), todo.Message, todo.Active);
            await _todoRepository.AddAsync(t);
            return _mapper.Map<TodoDto>(t);
        }

        public async Task UpdateAsync(Guid id)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null)
            {
                throw new Exception($"Todo with id='{id}' was not found.");
            }
            Todo t = Todo.Create(todo.Id, todo.Message, !todo.Active);

            await _todoRepository.UpdateAsync(t);
        }

        public async Task RemoveAsync(Guid id)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null)
            {
                throw new Exception($"Todo with id='{id}' was not found.");
            }
            await _todoRepository.RemoveAsync(todo);
        }

        public async Task<List<TodoDto>> GetAllAsync()
        {
            var todos = await _todoRepository.GetAllAsync();
            return _mapper.Map<List<TodoDto>>(todos);
        }

        public async Task<TodoDto> GetAsync(Guid id)
        {
            var todo = await _todoRepository.GetAsync(id);
            if (todo == null)
            {
                throw new Exception($"Todo with id='{id}' was not found.");
            }
            return _mapper.Map<TodoDto>(todo);
        }
    }
}