using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using TodoList.DTO;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todos = await _todoService.GetAllAsync();
            return Json(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoDto todoDto)
        {
            var todo = await _todoService.AddAsync(todoDto);
            return Json(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id)
        {
            await _todoService.UpdateAsync(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _todoService.RemoveAsync(id);
            return Ok();
        }


    }
}