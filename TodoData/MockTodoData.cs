using RestfulApiTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApiTodo.TodoData
{
    /************************************
         *
         *get all todos
         *
         *get single todo
         *
         *add todo
         *
         *edit todo
         *
         *delete todo
         * 
   **************************************/
    public class MockTodoData : ITodoData
    {

        private List<Todo> todos = new List<Todo>()
        {
            new Todo()
            {
                Id = "123",
                Title = "new title",
                Description = "description",
                IsComplete = false,
                Date = new DateTime(),
            },
            new Todo()
            {
                Id = "456",
                Title = "another new title",
                Description = "description2",
                IsComplete = false,
                Date = new DateTime()
            }
        };

        public Todo AddTodo(Todo todo)
        {
            //generate random number for id
            Random rnd = new Random();
            todo.Id = rnd.Next(1000).ToString();

            //default isComplete to false
            todo.IsComplete = false;
            todos.Add(todo);

            return todo;
        }

        public Todo DeleteTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Todo EditTodo()
        {
            throw new NotImplementedException();
        }

        public Todo GetTodo(string id)
        {
            //single todo by id
            //SingleOrDefault takes in a lamda expression to match the Id of the object
            return todos.SingleOrDefault(x => x.Id == id);
        }

        public List<Todo> GetTodos()
        {
            //return a list of todos
            return todos;
        }
    }
}
