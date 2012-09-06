using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopicDiscusser.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public int TopicId { get; set; }
    }
}