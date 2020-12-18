using RestfulApiTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApiTodo.TodoData
{
    public interface ITodoData
    {
        //get all todos
        List<Todo> GetTodos();

        //get single todo
        Todo GetTodo(string id);

        //add todo
        Todo AddTodo(Todo todo);

        //delete todo
        Todo DeleteTodo(Todo todo);

        //edit todo
        Todo EditTodo(Todo todo);
        

    };
}
