using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp
{
    public class Assgn10Context : DbContext
    {
        public Assgn10Context(DbContextOptions<Assgn10Context> options)
            : base(options)
        { }

        public DbSet<Entity.Assgn10Person> People { get; set; }

        public DbSet<Entity.Assgn10Accomplishment> Accomplishments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(@"Server=tcp:cis174demo.database.windows.net,1433;Initial Catalog=CIS174;Persist Security Info=False;User ID=nlbrown;Password=???????;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    }
}

    

