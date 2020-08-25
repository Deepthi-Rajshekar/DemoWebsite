using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalCourses.Models
{
    public class Office
    {
        public int Officeid { get; set; }
        [Required]
        public string Location { get; set; }

        //Foreign Key
        public int TutorId { get; set; }
        //Navigation property
        public Tutor Tutor { get; set; }
    }
}
