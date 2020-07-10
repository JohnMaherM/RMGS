using SP_ASPNET_1.DbFiles.Operations;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;
using System.Web.Mvc;
using System.Web.Routing;
using SP_ASPNET_1.BusinessLogic;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Notifications;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SP_ASPNET_1.Controllers
{
    [RoutePrefix("Blog")]
    public class BlogPostController : BaseController
    {
        private readonly BlogPostOperations _blogPostOperations = new BlogPostOperations();
        private readonly ReactionOperations _ReactionOperations = new ReactionOperations();

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            //return this.View();
            BlogIndexViewModel result = this._blogPostOperations.GetBlogIndexViewModel();
            ViewBag.Title = "Blog";
            return this.View(result);
        }


        [Route("Detail/{id:int?}")]
        [HttpGet]
        public ActionResult SinglePost(int? id)
        {
            ViewBag.Title = "single post";

            
            BlogSinglePostViewModel modelView;

            if (id == null)
            {
                modelView = this._blogPostOperations.GetLatestBlogPost();
            }
            else
            {
                modelView = this._blogPostOperations.GetBlogPostByIdFull((int)id);
            }

            return View(modelView);
        }

        [Route("Detail/Random")]
        [HttpGet]
        public ActionResult RandomPost()
        {
            ViewBag.Title = "Random post";

            var viewModel = this._blogPostOperations.GetRandomBlogPost();

            return View(viewModel);
        }

        [Route("LatestPost")]
        [HttpGet]
        public ActionResult LatestPost()
        {
            var viewModel = this._blogPostOperations.GetLatestBlogPost();

            return this.PartialView("~/Views/BlogPost/_BlogPostRecentPartialView.cshtml", viewModel);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(BlogPost blogPost)
        {
            try
            {
                this._blogPostOperations.Create(blogPost);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Edit/{id:int?}")]
        [HttpGet]
        public ActionResult EditBlogPost(int id)
        {
            BlogPost blogPost;

            blogPost = this._blogPostOperations.GetBlogPostByIdD((int)id);

            return View(blogPost);
        }

        [Route("Edit/{id:int}")]
        [HttpPost]
        public ActionResult Edit(int id, BlogPost blogPost)
        {
            try
            {

                // TODO: Add update logic here
               
                this._blogPostOperations.update(id,blogPost);
                // TODO: Return to detail
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Delete/{id:int}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                this._blogPostOperations.Delete(id);

                //CHECK: should return to blogs
                return RedirectToAction("Index");
            }
            catch
            {
                return this.HttpNotFound();
            }
        }
      
        public async Task<ActionResult> Reaction(int id, bool Like)
        {
            try
            {
                if(User.Identity.GetUserId() == null)
                {
                    return this.Json(JsonConvert.SerializeObject(-1), JsonRequestBehavior.AllowGet);

                }
                else
                {
                    if (Like)
                    {
                        BlogPostReaction blogPostReaction = new BlogPostReaction
                        {
                            BlogPostID = id,
                            UserID = User.Identity.GetUserId()

                        };
                        this._ReactionOperations.Create(blogPostReaction);


                    }
                    else
                    {
                        this._ReactionOperations.Delete(id);

                    }
                    JsonResult result = new JsonResult();
                    int count = _ReactionOperations.GetPostReactionsCount(id);
                    result = this.Json(JsonConvert.SerializeObject(count), JsonRequestBehavior.AllowGet);
                    return result;
                }
            }
            catch(Exception ex)
            {
                return this.Json(JsonConvert.SerializeObject(0), JsonRequestBehavior.AllowGet);

                return View();
            }
        }
        //[Route("Reaction/{blogPostID:int}/{blogPostID:bool}")]
        //[HttpPost]
        //public ActionResult Reaction(int blogPostID , bool IsLike)
        //{
        //    try
        //    {

        //        // TODO: Add update logic here
        //        if(IsLike)
        //        {
        //            BlogPostReaction blogPostReaction = new BlogPostReaction
        //            {
        //                BlogPostID = blogPostID,
        //                UserID = User.Identity.GetUserId()

        //                };
        //           this._ReactionOperations.Create(blogPostReaction);


        //        }
        //        else
        //        {
        //            this._ReactionOperations.Delete(blogPostID);
        //        }
        //        // TODO: Return to detail
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
