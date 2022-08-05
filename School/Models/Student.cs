using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class Student
    {     
        [Key]
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int GradeId { get; set; }
        public string Comments { get; set; }

        public Grade Grade { get; set; }
    }
}
