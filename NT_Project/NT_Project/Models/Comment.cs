using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string comment_message { get; set; }
        public ApplicationUser user { get; set; }
        public Post post { get; set; }
        public DateTime? comment_date { get; set; }

    }
}