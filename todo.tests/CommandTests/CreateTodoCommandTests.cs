using System;
using NUnit.Framework;
using todo.domain.Commands;

namespace todo.tests.CommandTests
{
    public class CreateTodoCommandTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenInvalidCommandTestShouldFail()
        {
            var command = new CreateTodoCommand("", "", new DateTime());
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }

        [Test]
        public void GivenValidCommandTestShouldFail()
        {
            var command = new CreateTodoCommand("Task title", "ypedroo", new DateTime());
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}