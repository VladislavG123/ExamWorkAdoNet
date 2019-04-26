namespace ExamWork
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
        }
        
         public DbSet<Country> Countries { get; set; }
         public DbSet<City> Cities { get; set; }
         public DbSet<Street> Streets { get; set; }
    }
    
}