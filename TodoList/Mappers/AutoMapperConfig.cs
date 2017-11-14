using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TodoList.Domain;
using TodoList.DTO;

namespace TodoList.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TodoDto, Todo>().ReverseMap();
                })
                .CreateMapper();
    }
}
