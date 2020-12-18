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
            /*
             *
             *  In postman you must send the post request using JSON in this format
             *      "title": "new title",
                    "description": "new description"
             *
            */ 

            //generate random number for id
            Random rnd = new Random();
            todo.Id = rnd.Next(1000).ToString();

            //default isComplete to false
            todo.IsComplete = false;

            //push new todo to list of todos
            todos.Add(todo);

            //this makes the compiler happy
            return todo;

        }

        public Todo DeleteTodo(Todo todo)
        {
            todos.Remove(todo);
            return todo;
        }

        public Todo EditTodo(Todo todo)
        {
            //get todo by id
            var foundTodo = GetTodo(todo.Id);

            //override values
            foundTodo.Title = todo.Title;
            foundTodo.Description = todo.Description;

            //make compiler happy
            return foundTodo;
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
