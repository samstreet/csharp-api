using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodoRepository _ItodoRepository;

        public TodosController(ITodoRepository todoRepository)
        {
            _ItodoRepository = todoRepository; 
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _ItodoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetTodoById(long id)
        {
            TodoItem item = _ItodoRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult NewToDoItem(TodoItem item)
        {
            return Ok(item);
        }

        [HttpPatch("{id}")]
        public IActionResult PutTodoItem(TodoItem item)
        {
            return Ok();
        }
    }
}
