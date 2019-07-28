using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Post
    {
        public int id { get; set; }
        public string post_message { get; set; }
        public DateTime? post_date { get; set; }
        public ApplicationUser user { get; set; }
        public ICollection<string> photos { get; set; }
        public ICollection<string> videos { get; set; }


    }
}