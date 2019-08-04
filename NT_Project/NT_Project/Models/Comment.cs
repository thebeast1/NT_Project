﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string comment_message { get; set; }
        public DateTime? comment_date { get; set; }


        public virtual ApplicationUser user { get; set; }
        public Post post { get; set; }

        public string user_id_for_comment { get; set; }
        public string post_id { get; set; }
        [NotMapped]
        public string user_name { get; set; }
    }
}