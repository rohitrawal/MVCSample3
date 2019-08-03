using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entity1
{
    public class SchoolContext: DbContext
    {
        public SchoolContext() : base()
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Grade> grades { get; set; }
    }
}