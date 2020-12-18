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
                id = "123",
                title = "new title",
                description = "description",
                isComplete = false,
                date = new DateTime()
            },
            new Todo()
            {
                id = "456",
                title = "another new title",
                description = "description2",
                isComplete = false,
                date = new DateTime()
            }
        };

        public Todo AddTodo(Todo todo)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Todo> GetTodos()
        {
            //return a list of todos
            return todos;
        }
    }
}
