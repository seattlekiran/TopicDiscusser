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
                        var routeData = request.GetRouteData();
                        var controller = routeData.Values["controller"];
                        var urlHelper = request.GetUrlHelper();

                        Topic topic = null;
                        Comment comment = null;
                        IEnumerable<Topic> topics = null;

                        if (response.TryGetContentValue<Topic>(out topic))
                        {
                            topic.SelfLink = new Uri(urlHelper.Route("DefaultApi", new { controller = controller, id = topic.Id }), UriKind.Relative);
                        }
                        else if (response.TryGetContentValue<Comment>(out comment))
                        {
                            comment.SelfLink = new Uri(urlHelper.Route("DefaultApi", new { controller = controller, id = comment.Id }), UriKind.Relative);
                        }
                    }

                    return response;
                });
        }

    }
}