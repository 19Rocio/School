using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class CourseGrade 
    { 
    
        [Key]
        public int Id
        {
            get; set;
        }
        public int GradeId
        {
            get; set;
        }
        public int CourseId { get; set; }
    }
}
