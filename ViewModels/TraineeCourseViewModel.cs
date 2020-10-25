using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingFPT.Models;

namespace TrainingFPT.ViewModels
{
    public class TraineeCourseViewModel
    {
        public TraineeCourse TraineeCourse { get; set; }
        public IEnumerable<ApplicationUser> Trainees { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}