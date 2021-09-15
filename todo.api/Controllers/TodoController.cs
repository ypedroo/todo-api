﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todo.domain.Commands;
using todo.domain.Entities;
using todo.domain.Handlers;
using todo.domain.Repositories;

namespace todo.api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("")]
        public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("mark-as-done")]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices]TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpPut]
        [Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices]TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAll(user);
        }
        
        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllDone([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAllDone(user);
        }
        
        [HttpGet]
        [Route("done/today")]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }
        
        [HttpGet]
        [Route("undone")]
        public IEnumerable<TodoItem> GetAllUndone([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAllUndone(user);
        }
        
        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.Now.Date, false);
        } 
        
        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
        }
    }
}