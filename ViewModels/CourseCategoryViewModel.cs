using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingFPT.Models;

namespace TrainingFPT.ViewModels
{
    public class CourseCategoryViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Topic> Topics { get; set; }

    }
}