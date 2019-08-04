using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NT_Project.Models;
using Microsoft.AspNet.Identity;
using NT_Project.ViewModel;
using System.IO;

namespace NT_Project.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.posts.ToList());
        }

        
        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

       
        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            
            if (ModelState.IsValid&&string.IsNullOrEmpty(post.post_message)==false)
            {
                 //ImgFile = Request.Files["ImgFile"];
                //if (ImgFile != null)
                //{
                //    string filename = Path.GetFileNameWithoutExtension(ImgFile.FileName);
                //    string extension = Path.GetExtension(ImgFile.FileName);
                //    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                //    post.url = "~/Image/" + filename;
                //    filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                //    ImgFile.SaveAs(filename);
                //}
                var cur_user = User.Identity.GetUserId();
                //ApplicationUser current_user = new ApplicationUser();
                //var user = from userss in db.Users
                //           where userss.Id == cur_user
                //           select userss;
                //foreach (var i in user)
                //    current_user = i;
                //post.user = current_user;
                post.post_date = DateTime.Now;
                post.user_id_for_posts = cur_user;
                db.posts.Add(post);
                db.SaveChanges();
                
                return RedirectToAction("Index","Home");
            }
            
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,post_message,post_date,user_id_for_posts")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.posts.Find(id);
            db.posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
