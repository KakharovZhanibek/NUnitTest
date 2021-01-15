using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DB
{
    public class Context : DbContext
    {
        public Context() : base("myConn")
        { }
        public DbSet<City> City { get; set; }
    }
}