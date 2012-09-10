using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TopicDiscusser.Models
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public int Votes { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }

        [DataMember]
        public DateTime UpdatedDate { get; set; }

        [DataMember]
        public Uri SelfLink { get; set; }

        //TODO: provide a topic link
        //[DataMember]
        //public Uri TopicLink { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}