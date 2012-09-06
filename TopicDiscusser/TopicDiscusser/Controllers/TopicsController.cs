using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TopicDiscusser.Models;

namespace TopicDiscusser.Controllers
{
    public class TopicsController : ApiController
    {
        // GET api/topics
        public IEnumerable<Topic> Get()
        {
            return null;
        }

        /// <summary>
        /// Gets a topic of  athe given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Topic Get(int id)
        {
            return null;
        }

        /// <summary>
        /// Creates a new topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(Topic topic)
        {
            return null;
        }

        /// <summary>
        /// Updates topic details like : title, description, attachments
        /// </summary>
        /// <param name="id"></param>
        /// <param name="topic"></param>
        public HttpResponseMessage Put(int id, Topic topic)
        {
            return null;
        }

        /// <summary>
        /// Deletes a topic
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
            return null;
        }
    }
}
