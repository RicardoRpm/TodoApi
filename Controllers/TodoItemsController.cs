using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Infra;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    public class TodoItemsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public TodoItemsController(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        [HttpGet("/")]
        public ActionResult<List<TodoItem>> GetItems(){
            return Ok(_appDbContext.TodoItems.ToList());
        }

        [HttpPost("/")]
        public ActionResult<List<TodoItem>> Post(
            [FromBody] TodoItem item)
        {
            _appDbContext.TodoItems.Add(item);
            _appDbContext.SaveChanges();
            return Created($"/{item.Id}", item);
        }

        [HttpDelete("/{id:int}")]
        public ActionResult<List<TodoItem>> Delete(
            [FromRoute] int id)
        {
            var modelItem = _appDbContext.TodoItems.SingleOrDefault(a => a.Id == id);
            if (modelItem is not null){
                return NotFound();
            }

            _appDbContext.TodoItems.Remove(modelItem);
            _appDbContext.SaveChanges();
            return Ok(modelItem);
        }

        [HttpPut("/{id:int}")]
        public ActionResult<List<TodoItem>> Update(
            [FromBody] TodoItem item,
            [FromRoute] int id

        )
        {
            var model = _appDbContext.TodoItems.FirstOrDefault(a => a.Id == id);
            if (model is null)
            {
                return NotFound();
            }

            model.IsCompleted = item.IsCompleted;
            model.Title = item.Title;
            return Ok(model);
        }
    }
}