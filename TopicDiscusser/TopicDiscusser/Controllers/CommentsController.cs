using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TopicDiscusser.Models;

namespace TopicDiscusser.Controllers
{
    public class CommentsController : ApiController
    {
        /// <summary>
        /// Gets list of all comments associated with a given topic.
        /// The comments are arranged in descending order.
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        public IEnumerable<Comment> Get(int topicId)
        {
            return null;
        }

        /// <summary>
        /// Creates a new comment for a given topic.
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(int topicId)
        {
            return null;
        }

        /// <summary>
        /// Update a given comment.
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <param name="comment">Updated comment</param>
        public HttpResponseMessage Put(int id, Comment comment)
        {
            return null;
        }

        /// <summary>
        /// Deletes a given comment
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            return null;
        }
    }
}
