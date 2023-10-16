using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> opt) 
            : base(opt)
        {

        }
    }
}