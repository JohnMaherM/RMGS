using Microsoft.AspNet.Identity;
using SP_ASPNET_1.DbFiles.UnitsOfWork;
using SP_ASPNET_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SP_ASPNET_1.DbFiles.Operations
{
    public class ReactionOperations
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public async void Delete(int id)
        {
            try
            {
                BlogPostReaction post = this.BlogPostReactionID(id);


                this._unitOfWork.BlogPostReactionRepository.Remove(post);
                this._unitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public void Create(BlogPostReaction blogPost)
        {
            try
            {
                this._unitOfWork.BlogPostReactionRepository.Insert(blogPost);
                this._unitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public  BlogPostReaction  BlogPostReactionID(int id)
        {

            return  _unitOfWork.BlogPostReactionRepository.Entities.Where(x => x.BlogPostID == id).FirstOrDefault();
        }
        public  int GetPostReactionsCount(int id)
        {
            string currentUser= System.Web.HttpContext.Current.User.Identity.GetUserId();
            List<BlogPostReaction> BlogPostReaction =  _unitOfWork.BlogPostReactionRepository.Entities.Where(x => x.BlogPostID == id).ToList();
            return BlogPostReaction.Count() ;
        }
    }
}