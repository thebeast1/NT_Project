using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class React
    {
        public int id { get; set; }
        public ApplicationUser user { get; set; }
        public Post post { get; set; }
        public Comment comment { get; set; }
    }
}