using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TopicDiscusser.Models;

namespace TopicDiscusser.MessageHandlers
{
    public class LinkGenerationHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>((tsk) =>
                {
                    HttpResponseMessage response = tsk.Result;

                    if (response.IsSuccessStatusCode && response.Content != null)
                    {
                        Topic topic = null;
                        IEnumerable<Topic> topics = null;

                        if (response.TryGetContentValue<Topic>(out topic))
                        {
                            GenerateLinksForTopic(topic, request);
                        }
                        else if (response.TryGetContentValue<IEnumerable<Topic>>(out topics))
                        {
                            var objectContent = (ObjectContent<IEnumerable<Topic>>)response.Content;
                            objectContent.Value = topics.Select(tpc => GenerateLinksForTopic(tpc, request));
                        }
                    }

                    return response;
                });
        }

        private static Topic GenerateLinksForTopic(Topic topic, HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            var controller = routeData.Values["controller"];
            var urlHelper = request.GetUrlHelper();

            topic.SelfLink = new Uri(urlHelper.Route("DefaultApi", new { controller = controller, id = topic.Id }), UriKind.Relative);

            if (topic.Comments != null && topic.Comments.Count > 0)
            {
                topic.Comments = new List<Comment>(topic.Comments.Select((cmt) =>
                {
                    cmt.SelfLink = new Uri(urlHelper.Route("DefaultApi", new { controller = controller, id = cmt.Id }), UriKind.Relative);
                    cmt.TopicLink = new Uri(urlHelper.Route("DefaultApi", new { controller = "topics", id = cmt.TopicId }), UriKind.Relative);

                    return cmt;
                }));
            }

            if (topic.Tags != null && topic.Tags.Count > 0)
            {
                topic.Tags = new List<Tag>(topic.Tags.Select((tag) =>
                {
                    tag.SelfLink = new Uri(urlHelper.Route("DefaultApi", new { controller = controller, tags = tag.Name }), UriKind.Relative);
                    return tag;
                }));
            }

            return topic;
        }
    }
}