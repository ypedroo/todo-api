using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using todo.domain.Entities;
using todo.domain.Queries;

namespace todo.tests.EntityTests
{
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        [SetUp]
        public void Setup()
        {
            _items = new List<TodoItem>
            {
                new("Task1", DateTime.Now, "user"),
                new("Task2", DateTime.Now, "naruto"),
                new("Task3", DateTime.Now, "user"),
                new("Task4", DateTime.Now, "user"),
                new("Task5", DateTime.Now, "naruto"),
                new("Task6", DateTime.Now, "user"),
            };
        }

        [Test]
        public void GivenQueryShouldReturnRefUseTask()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("naruto"));
            Assert.AreEqual(2,result.Count());
        }
    }
}