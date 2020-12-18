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

        //get one
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

    }
}
