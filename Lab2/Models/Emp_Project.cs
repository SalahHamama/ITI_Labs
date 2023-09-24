using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    [PrimaryKey("emp_id", "proj_id")]
    public class Emp_Project
    {
        [ForeignKey("Employee")]
        public int emp_id { get; set; }
        [ForeignKey("Project")]
        public int proj_id { get; set; }
        public int Working_Hours { get; set; }
        public Employee? Employee { get; set; }
        public Project? Project { get; set; }
    }
}
