using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int age { get; set; }
        public string? Address { get; set; }
        public int Salary { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [ForeignKey("Office")]
        public int Office_Id { get; set; }
        public Office? Office { get; set; }
        public List<Emp_Project>? Emp_Projects { get; set; }
    }
}
