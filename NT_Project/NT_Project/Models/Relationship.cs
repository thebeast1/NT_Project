using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Status { get; set; }

        public string UserId { get; set; }
        public string FriendId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser Friend { get; set; }
    }
}