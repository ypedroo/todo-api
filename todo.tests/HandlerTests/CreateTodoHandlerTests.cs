using System;
using NUnit.Framework;
using todo.domain.Commands;
using todo.domain.Handlers;
using todo.tests.Repositories;

namespace todo.tests.HandlerTests
{
    public class CreateTodoHandlerTests
    {
        private CreateTodoCommand _validCommand;
        private CreateTodoCommand _invalidCommand;
        private TodoHandler _handler;
        
        [SetUp]
        public void Setup()
        {
            _validCommand =  new CreateTodoCommand("Task title", "ypedroo", new DateTime());
            _invalidCommand =  new CreateTodoCommand("", "", new DateTime());
            _handler =  new TodoHandler(new FakeTodoRepository());
        }

        [Test]
        public void GivenInvalidCommandTestShouldReturnGenericFinishExecution()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(false, result.Success);
        }

        [Test]
        public void GivenValidCommandTestShouldCreateTask()
        {
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(true, result.Success);
        }
    }
}