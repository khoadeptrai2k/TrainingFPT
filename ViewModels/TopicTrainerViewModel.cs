using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingFPT.Models;

namespace TrainingFPT.ViewModels
{
    public class TopicTrainerViewModel
    {
        public Trainer Trainer { get; set; }
        public IEnumerable<Topic> topics { get; set; }
        public IEnumerable<Course> courses { get; set; }

    }
}