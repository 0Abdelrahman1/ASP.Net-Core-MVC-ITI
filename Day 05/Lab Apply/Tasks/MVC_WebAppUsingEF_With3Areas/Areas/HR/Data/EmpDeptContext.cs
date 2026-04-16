using Microsoft.EntityFrameworkCore;
using MVC_WebAppUsingEF_With3Areas.Areas.HR.Models;
using System.Data.Common;

namespace MVC_WebAppUsingEF_With3Areas.Areas.HR.Data
{
    public class EmpDeptContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EmpDeptDB_MVC;Integrated Security=True; Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
