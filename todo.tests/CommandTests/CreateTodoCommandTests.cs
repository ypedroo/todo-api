using System;
using NUnit.Framework;
using todo.domain.Commands;

namespace todo.tests.CommandTests
{
    public class CreateTodoCommandTests
    {
        private CreateTodoCommand _validCommand;
        private CreateTodoCommand _invalidCommand;
        [SetUp]
        public void Setup()
        {
            _validCommand =  new CreateTodoCommand("Task title", "ypedroo", new DateTime());
            _invalidCommand =  new CreateTodoCommand("", "", new DateTime());
        }

        [Test]
        public void GivenInvalidCommandTestShouldFail()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(false, _invalidCommand.Valid);
        }

        [Test]
        public void GivenValidCommandTestShould()
        {
            _validCommand.Validate();
            Assert.AreEqual(true, _validCommand.Valid);
        }
    }
}