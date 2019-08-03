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
        
        public ActionResult Index()
        {

            var cur_id = User.Identity.GetUserId();
            var friends1 = from relationship in db.Relationships
                           where relationship.UserId == cur_id
                           where relationship.Status == 2
                           select relationship.FriendId;

            var friends2 = from relationship in db.Relationships
                           where relationship.FriendId == cur_id
                           select relationship.UserId;

            var friends = friends1.ToList().Concat(friends2.ToList()).ToList();

            List<Post> Posts = new List<Post>();
            if (friends!= null)
            {
                foreach (var items in friends)
                {

                    foreach (var posts2 in db.posts)
                    {
                        if (posts2.user_id_for_posts == items)
                        {
                            var name = from user in db.Users
                                       where user.Id == posts2.user_id_for_posts
                                       select user.FullName;
                            var comms = from com in db.comments
                                        where com.post_id == posts2.id.ToString()
                                        select com.id;
                            posts2.no_of_comms = comms.ToList().Count.ToString();
                            foreach (string i in name)
                            posts2.name = i;
                            Posts.Add(posts2);
                            
                        }
                    }
                }
            }
            
            
                foreach (var posts in db.posts)
                {
                    if (posts.user_id_for_posts == cur_id)
                    {
                    var name = from user in db.Users
                               where user.Id == posts.user_id_for_posts
                               select user.FullName;

                    var comms = from com in db.comments
                                where com.post_id == posts.id.ToString()
                                select com.id;
                    posts.no_of_comms = comms.ToList().Count.ToString();
                    foreach (string i in name)
                        posts.name = i;
                    Posts.Add(posts);
                }

                }

            var ord_posts = from p in Posts
                            orderby p.post_date
                            select p;
            
                return View(ord_posts.ToList());
        }

        public ActionResult AddprofilePic()
        {
            return View();
        }
        //[HttpPost]
        //public Action AddProfile()
        //{
            
        //}

        public ActionResult Friends()
        {
            var myID = User.Identity.GetUserId();

            var users = (from relations in db.Relationships
                        join user in db.Users
                        on relations.UserId equals user.Id
                        where (relations.FriendId == myID )
                        where relations.Status == 2
                        select user).ToList();

            var users2 = (from relations in db.Relationships
                        join user in db.Users
                        on relations.FriendId equals user.Id
                        where ( relations.UserId == myID)
                        where relations.Status == 2
                        select user).ToList();

            return View(users.Concat(users2).ToList());
        }


        [Authorize]
        public ActionResult AddFriend( string id)
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

            return RedirectToAction("Index");
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

            return View(users);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Requests()
        {
            var myID = User.Identity.GetUserId();

            var users = from relations in db.Relationships
                        join user in db.Users
                        on relations.UserId equals user.Id
                        where relations.FriendId == myID
                        where relations.Status == 1
                        select user;
            
            return View(users.ToList());
        }

        public ActionResult AcceptFriend(string id)
        {
            var myID = User.Identity.GetUserId();
            var relation = db.Relationships.Where(a => a.UserId == id && a.FriendId == myID).FirstOrDefault();

            relation.Status = 2;
            db.Entry(relation).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

       

       

    }
}