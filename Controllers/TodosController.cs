using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulApiTodo.Models;
using RestfulApiTodo.TodoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApiTodo.Controllers
{
    /********************************
     *
     *  Handles routes for CRUD operations
     * 
    *********************************/
    
    [ApiController]
    public class TodosController : ControllerBase
    {

        private ITodoData _todoData;

        //inject ITodo data
        public TodosController(ITodoData todoData)
        {
            //encapsulate the todoData
            _todoData = todoData;
        }

        //get all
        [HttpGet]
        //route = "api/todos"
        [Route("api/[controller]")]
        public IActionResult GetTodos()
        {
            //wrap result in an http ok response
            return Ok(_todoData.GetTodos());
        }

        //get one by id
        [HttpGet]
        //route = "api/todos/id"
        [Route("api/[controller]/{id}")]
        public IActionResult GetTodo(string id)
        {
            var todo = _todoData.GetTodo(id);

            //null check
            if(todo != null)
            {
                //wrap result in an http ok response
                return Ok(_todoData.GetTodo(id));
            }
            return NotFound($"The id of the todo item: {id} was not found!");
        }

        //add one
        [HttpPost]
        //route = "api/todos"
        [Route("api/[controller]")]
        public IActionResult AddTodo(Todo todo)
        {
            //create new todo
            _todoData.AddTodo(todo);

            //returns a (201) created
            //Created(string location, object content)
                //HttpContext.Request.Scheme = https or http
                //HttpContext.Request.Host = host port
                //HttpContext.Request.Path = current url
                //add the id to the end of the path so Created() can check if it was created or not
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + todo.Id, todo);
            
        }

        //delete one by id
        [HttpDelete]
        //route = "api/todos"
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteTodo(string id)
        {
            //get targeted todo by id, if any todo matches that id then remove from list
            var todo = _todoData.GetTodo(id);

            if(todo != null)
            {
                _todoData.DeleteTodo(todo);
                //signals successful deletion
                return Ok();
            }

            return NotFound($"The id of the todo item: {id} was not found! Could not be deleted");
        }

        //edit one by id
        [HttpPatch]
        //route = "api/todos"
        [Route("api/[controller]/{id}")]
        public IActionResult EditTodo(string id, Todo todo)
        {
            //find todo by id
            var foundTodo = _todoData.GetTodo(id);

            //null check todo
            if (foundTodo != null)
            {
                //set foundTodo.Id equal to todo in params so the program can edit object with the same id
                todo.Id = foundTodo.Id;
                //edit
                _todoData.EditTodo(todo);
                //signals successful edit
                return Ok();
            }
            return NotFound($"The id of the todo item: {id} was not found! Could not be edited");
        }

    }
}
