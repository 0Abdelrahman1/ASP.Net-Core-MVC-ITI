using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_WebAppUsingEF_With3Areas.Areas.HR.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        
        [ForeignKey("Department")]
        public int DeptID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
