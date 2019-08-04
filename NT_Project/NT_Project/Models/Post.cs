using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Post
    {
        public int id { get; set; }
        public string post_message { get; set; }
        public DateTime? post_date { get; set; }
        public virtual ApplicationUser user { get; set; }
        public ICollection<string> photos { get; set; }
        public ICollection<string> videos { get; set; }

        public virtual ICollection<Comment> comments { get; set; }

        public string user_id_for_posts { get; set; }
        [NotMapped]
        public string name { get; set; }
        [NotMapped]
        public string no_of_comms { get; set; }

        [NotMapped]
        public string pic { get; set; }

        [NotMapped]
        public ApplicationUser user2 { get; set; }

        public string url { get; set; }

        //[NotMapped]
        //public HttpPostedFileBase ImgFile { get; set; }
    }
}