using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TopicDiscusser.Models
{
    [DataContract]
    public class Tag
    {
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Uri SelfLink { get; set; }
    }
}