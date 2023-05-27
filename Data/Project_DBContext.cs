using Microsoft.EntityFrameworkCore;
using Sample_DotNetCore_WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_DotNetCore_WebAPI.Data
{
    //Sayantan
    //In EF Core DbContext is like a database that manages all POCO classes(classes represent tables)
    public class Project_DBContext : DbContext
    {
        public Project_DBContext(DbContextOptions<Project_DBContext> options) : base(options)
        {

        }
        public DbSet<Gadgets> Gadgets { get; set; }
    }
}
