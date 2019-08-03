using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace REntity
{
    public class SchoolContext: DbContext
    {
        public SchoolContext() : base("School")
        {
            //Database.SetInitializer<SchoolContext>(new DropCreateDatabaseIfModelChanges<SchoolContext>());
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Grade> grades { get; set; }
    }
}