using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulApiTodo.TodoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApiTodo.Controllers
{
    /********************************
     *
     *  Handles routes
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

    }
}
