﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TopicDiscusser.Filters;
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

        [Queryable]
        public IEnumerable<Topic> GetTopics()
        {
            return db.Topics.AsEnumerable();
        }

        public Topic GetTopic(int id)
        {
            //TODO: change to query expression
            Topic topic = db.Topics
                                .Where(tpc => tpc.Id == id)
                                .Include("Comments")
                                .FirstOrDefault();

            if (topic == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return topic;
        }

        [AuthorizeFilter]
        public HttpResponseMessage PutVote(int id, string vote)
        {
            if (ModelState.IsValid)
            {
                Topic topic = db.Topics.Find(id);

                if (topic == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                try
                {
                    if (vote.ToLowerInvariant() == "up")
                    {
                        topic.Votes += 1;
                    }
                    else if (vote.ToLowerInvariant() == "down")
                    {
                        topic.Votes -= 1;
                    }

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

        // PUT api/Topics/5
        //public HttpResponseMessage PutTopic(int id, Topic topic)
        //{
        //    if (ModelState.IsValid && id == topic.Id)
        //    {
        //        db.Entry(topic).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        // POST api/Topics

        [AuthorizeFilter]
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

        [AuthorizeFilter]
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