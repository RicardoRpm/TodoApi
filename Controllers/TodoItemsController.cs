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
    }
}