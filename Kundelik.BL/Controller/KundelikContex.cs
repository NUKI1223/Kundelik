using Kundelik.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Controller
{
    public class KundelikContex: DbContext
    {
        public KundelikContex() : base("DBConnection")
        {

        }
        public DbSet<Genders> DBGender { get; set; }
        public DbSet<Posts> DBPost { get; set; }
        public DbSet<Student> DBStudent { get; set; }
        public DbSet<Teacher> DBTeacher { get; set; }
    }
}
