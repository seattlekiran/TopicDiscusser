using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TopicDiscusser.Models
{
    [DataContract]
    public class Topic
    {
        public Topic()
        {
            this.Comments = new List<Comment>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Votes { get; set; }

        //TODO: this should be db generated and that too
        //only during creation of this record
        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string LastUpdatedBy { get; set; }

        //TODO: the first time we create a record, this should be db generated
        // and also for any other updates this should be db generated
        [DataMember]
        public DateTime LastUpdatedDate { get; set; }

        [DataMember]
        public List<Comment> Comments { get; set; }

        [DataMember]
        public Uri SelfLink { get; set; }
    }
}