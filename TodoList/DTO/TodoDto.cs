using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.DTO
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool Active { get; set; }
    }
}
