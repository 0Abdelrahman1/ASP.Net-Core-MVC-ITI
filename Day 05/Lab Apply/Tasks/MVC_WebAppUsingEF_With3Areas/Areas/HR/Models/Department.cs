using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_WebAppUsingEF_With3Areas.Areas.HR.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int DeptID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
