using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingFPT.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string WorkingPlace { get; set; }
        public string Phone { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

    }
}