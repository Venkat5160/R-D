using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TodoListApplication.Models;

namespace TodoListApplication.TodoContext
{
    public class TodoContext:DbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
    }
}