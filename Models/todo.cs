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
        public string id { get; set; }
        public string title { get; set; } 
        public string description { get; set; }
        public bool isComplete { get; set; }
        public DateTime date { get; set; }
    }
}
