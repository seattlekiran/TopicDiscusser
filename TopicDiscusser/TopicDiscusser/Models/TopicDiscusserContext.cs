using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace TopicDiscusser.Models
{
    public class TopicDiscusserContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TopicDiscusser.Models.TopicDiscusserContext>());

        public TopicDiscusserContext() : base("name=TopicDiscusserContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TopicEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new CommentEntityTypeConfiguration());
        }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }

    public class TopicEntityTypeConfiguration : EntityTypeConfiguration<Topic>
    {
        public TopicEntityTypeConfiguration()
        {
            this.Property(topic => topic.Title).HasMaxLength(100);
            this.Property(topic => topic.Description).HasMaxLength(1000);
            this.Property(topic => topic.CreatedBy).HasMaxLength(25);
            this.Property(topic => topic.LastUpdatedBy).HasMaxLength(25);
            this.Ignore(topic => topic.SelfLink);
            this.HasMany(topic => topic.Comments).WithRequired(comment => comment.Topic);
        }
    }

    public class CommentEntityTypeConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentEntityTypeConfiguration()
        {
            this.Property(comment => comment.Description).HasMaxLength(500);
            this.Property(comment => comment.CreatedBy).HasMaxLength(25);
            this.Property(comment => comment.UpdatedBy).HasMaxLength(25);
            this.Ignore(comment => comment.SelfLink);
        }
    }
}
