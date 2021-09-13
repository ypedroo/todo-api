using System;
using NUnit.Framework;
using todo.domain.Entities;
using static System.DateTime;

namespace todo.tests.EntityTests
{
    public class TodoItemTests
    {
        private TodoItem _todoItem;

        [SetUp]
        public void Setup()
        {
            _todoItem = new TodoItem("Title", new DateTime(), "ynoaPedro");
        }
        [Test]
        public void GivenNewTodoItMustBeUndone()
        {
            Assert.AreEqual(false, _todoItem.Done);
        }
    }
}