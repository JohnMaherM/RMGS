using SP_ASPNET_1.DbFiles.Contexts;
using SP_ASPNET_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace SP_ASPNET_1.DbFiles.Repositories.RepositoryDecorators
{
    
    public class BlogPostReactionRepository : BaseRepository<BlogPostReaction>
    {
        public BlogPostReactionRepository(IceCreamBlogContext context) : base(context)
        {

        }

        public new BlogPostReaction GetByID(object ID)
        {
            //TODO: IncludeImagePrefix dirty
            return (new BlogPostReaction[] { this.GetByID(ID) })
                .FirstOrDefault();
        }

        public new Task<IEnumerable<BlogPostReaction>> GetAsync(Expression<Func<BlogPost, bool>> filter = null, Func<IQueryable<BlogPostReaction>, IOrderedQueryable<BlogPostReaction>> orderBy = null, string includeProperties = "")
        {
            //TODO: IncludeImagePrefix dirty
            return new Task<IEnumerable<BlogPostReaction>>(() =>
            {
                return this.GetAsync(filter, orderBy, includeProperties).Result;
            });
        }

        //TODO: IncludeImagePrefix dirty
        public new IEnumerable<BlogPostReaction> Get(Expression<Func<BlogPostReaction, bool>> filter = null, Func<IQueryable<BlogPostReaction>, IOrderedQueryable<BlogPostReaction>> orderBy = null, string includeProperties = "")
        {
            return base.Get(filter, orderBy, includeProperties);
        }
    }

}