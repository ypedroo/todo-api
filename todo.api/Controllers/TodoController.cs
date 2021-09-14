using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo.domain.Commands;
using todo.domain.Entities;
using todo.domain.Handlers;
using todo.domain.Repositories;

namespace todo.api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "ypedroo";
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("")]
        public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "ypedroo";
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("mark-as-done")]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "ypedroo";
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "ypedroo";
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
        {
            return repository.GetAll("ypedroo");
        }
        
        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllDone([FromServices]ITodoRepository repository)
        {
            return repository.GetAllDone("ypedroo");
        }
        
        [HttpGet]
        [Route("done/today")]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod("ypedroo", DateTime.Now.Date, true);
        }

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod("ypedroo", DateTime.Now.Date.AddDays(1), true);
        }
        
        [HttpGet]
        [Route("undone")]
        public IEnumerable<TodoItem> GetAllUndone([FromServices]ITodoRepository repository)
        {
            return repository.GetAllUndone("ypedroo");
        }
        
        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod("ypedroo", DateTime.Now.Date, false);
        } 
        
        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices]ITodoRepository repository)
        {
            return repository.GetByPeriod("ypedroo", DateTime.Now.Date.AddDays(1), false);
        }
    }
}