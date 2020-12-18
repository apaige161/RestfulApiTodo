using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApiTodo.Models
{
    /********************************
     *
     *  Properties for the model of data
     * 
    */ 
    public class Todo
    {
        //model the data
        public string Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime Date { get; set; }
    }
}
