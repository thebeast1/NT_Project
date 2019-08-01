using Microsoft.AspNet.Identity;
using NT_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NT_Project.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Friends()
        {
            var myID = User.Identity.GetUserId();

            var users = (from relations in db.Relationships
                         join user in db.Users
                         on relations.UserId equals user.Id
                         where (relations.FriendId == myID)
                         where relations.Status == 2
                         select user).ToList();

            var users2 = (from relations in db.Relationships
                          join user in db.Users
                          on relations.FriendId equals user.Id
                          where (relations.UserId == myID)
                          where relations.Status == 2
                          select user).ToList();
            if (User.IsInRole("CanShowUsers"))
                return View("Index");
            return View(users.Concat(users2).ToList());
            

        }


        [Authorize]
        public ActionResult AddFriend(string id)
        {
            //  1 => request - 2 => friend
            var myID = User.Identity.GetUserId();

            db.Relationships.Add(new Relationship
            {
                UserId = myID,
                FriendId = id,
                Status = 1,
                Date = DateTime.Now
            });
            db.SaveChanges();

            if (User.IsInRole("CanShowUsers"))
                return View("Index");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "CanShowUsers")]
        public ActionResult DeleteUser(string id)
        {


            NT_Project.Models.ApplicationUser user = db.Users.Where(a => a.Id == id).FirstOrDefault();

            NT_Project.Models.Relationship relation = db.Relationships.Where(a => a.UserId  == id || a.FriendId == id).FirstOrDefault();

            var postt = (from Post in db.posts
                        where Post.user_id_for_posts.ToString() == id
                        select Post).ToList();

            if (postt.Count() > 0)
            {
                NT_Project.Models.Post post_delete = db.posts.Where(a => a.user_id_for_posts.ToString() == id ).FirstOrDefault();

                db.posts.Remove(post_delete);

            }

            var com = (from Comment in db.comments
                         where Comment.user_id_for_comment.ToString() == id
                         select Comment).ToList();

            if (com.Count() > 0)
            {
                NT_Project.Models.Comment comm_delete = db.comments.Where(a => a.user_id_for_comment.ToString() == id).FirstOrDefault();

                db.comments.Remove(comm_delete);

            }


            var relt = (from relationship in db.Relationships
                         where relationship.UserId.ToString() == id
                         select relationship).ToList();
            if(relt.Count()>0)
            db.Relationships.Remove(relation);

            db.Users.Remove(user);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "CanShowUsers")]
        public ActionResult showusers()  //de hna ely bte3redly kol al users ely fl database
        {
            var myID = User.Identity.GetUserId();

            var list_users = (from user in db.Users
                              where user.Id != myID
                             select user).ToList();
          
            return View(list_users);
        }

        [Authorize]
        public ActionResult Search(string search)
        {
            var myID = User.Identity.GetUserId();
            var friends1 = from relationship in db.Relationships
                           where relationship.UserId == myID
                           select relationship.FriendId;


            var friends2 = from relationship in db.Relationships
                           where relationship.FriendId == myID
                           select relationship.UserId;

            ViewBag.userRelation = friends1.ToList().Concat(friends2.ToList()).ToList();
            
            var users = db.Users.Where( a => a.Id != myID && (a.FullName.Contains(search) || 
                                        a.Email.Contains(search) || a.PhoneNumber.Contains(search)) ).ToList();
            if (User.IsInRole("CanShowUsers"))
                return View("Index");
            return View(users);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Requests()
        {
            var myID = User.Identity.GetUserId();

            var users = from relations in db.Relationships
                        join user in db.Users
                        on relations.UserId equals user.Id
                        where relations.FriendId == myID
                        where relations.Status == 1
                        select user;

            if (User.IsInRole("CanShowUsers"))
                return View("Index");
            return View(users.ToList());
        }
        [Authorize]
        public ActionResult AcceptFriend(string id)
        {
            var myID = User.Identity.GetUserId();
            var relation = db.Relationships.Where(a => a.UserId == id && a.FriendId == myID).FirstOrDefault();

            relation.Status = 2;
            db.Entry(relation).State = EntityState.Modified;
            db.SaveChanges();

            if (User.IsInRole("CanShowUsers"))
                return View("Index");
            return RedirectToAction("Index");
        }


    }
}