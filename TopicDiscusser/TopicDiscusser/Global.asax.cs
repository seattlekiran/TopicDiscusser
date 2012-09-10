using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TopicDiscusser.Models;

namespace TopicDiscusser
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // Ideally this line should not be present here (ex: production). During development time when there are frequent mdoel changes this is useful.
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TopicDiscusser.Models.TopicDiscusserContext>());

            //// Create sample data. Calling 'SaveChanges()' will create a database for us and will
            //// insert this record
            //Topic topic1 = new Topic();
            //topic1.Title = "Provide a plain text formatter";
            //topic1.Description = "Provide a plain text formatter";
            //topic1.CreatedDate = DateTime.UtcNow;
            //topic1.LastUpdatedDate = DateTime.UtcNow;
            //topic1.Votes = 0;
            //topic1.CreatedBy = "kichalla";
            //topic1.LastUpdatedBy = "kichalla";

            //Comment topic1Comment1 = new Comment();
            //topic1Comment1.Topic = topic1;
            //topic1Comment1.UpdatedBy = "ram";
            //topic1Comment1.CreatedBy = "ram";
            //topic1Comment1.CreatedDate = DateTime.UtcNow.AddDays(2);
            //topic1Comment1.UpdatedDate = DateTime.UtcNow.AddDays(2);
            //topic1Comment1.Description = "That would be awesome!. I am in so much need of it.";

            //topic1.Comments.Add(topic1Comment1);

            //Topic topic2 = new Topic();
            //topic2.Title = "Provide in-built support for Accept-Encoding";
            //topic2.Description = "Provide in-built support for Accept-Encoding.";
            //topic2.CreatedDate = DateTime.UtcNow;
            //topic2.LastUpdatedDate = DateTime.UtcNow;
            //topic2.Votes = 0;
            //topic2.CreatedBy = "kichalla";
            //topic2.LastUpdatedBy = "kichalla";

            //Comment topic2Comment1 = new Comment();
            //topic2Comment1.Topic = topic2;
            //topic2Comment1.UpdatedBy = "ram";
            //topic2Comment1.CreatedBy = "ram";
            //topic2Comment1.CreatedDate = DateTime.UtcNow.AddDays(2);
            //topic2Comment1.UpdatedDate = DateTime.UtcNow.AddDays(2);
            //topic2Comment1.Description = "That would be awesome!. I am in so much need of it.";

            //topic2.Comments.Add(topic2Comment1);

            //using (TopicDiscusserContext db = new TopicDiscusserContext())
            //{
            //    db.Topics.Add(topic1);
            //    db.Topics.Add(topic2);
            //    db.SaveChanges();
            //}
        }
    }
}