using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TopicDiscusser.Models;

namespace TopicDiscusser.Controllers
{
    public class TopicsController : ApiController
    {
        private TopicDiscusserContext db = new TopicDiscusserContext();

        //TODO: repository pattern
        public TopicsController()
        {
        }

        // GET api/Topics
        public IEnumerable<Topic> GetTopics()
        {
            return db.Topics.AsEnumerable();
        }

        // GET api/Topics/5
        public Topic GetTopic(int id)
        {
            //TODO: include Comments details too
            Topic topic = db.Topics.Find(id);

            if (topic == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return topic;
        }

        // PUT api/Topics/5
        public HttpResponseMessage PutTopic(int id, Topic topic)
        {
            if (ModelState.IsValid && id == topic.Id)
            {
                db.Entry(topic).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Topics
        public HttpResponseMessage PostTopic(Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, topic);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = topic.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Topics/5
        public HttpResponseMessage DeleteTopic(int id)
        {
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Topics.Remove(topic);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, topic);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}