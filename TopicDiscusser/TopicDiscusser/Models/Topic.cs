using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TopicDiscusser.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Votes { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}