using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Relationship
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Status { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Friend")]
        public string FriendId { get; set; }
        public virtual ApplicationUser Friend { get; set; }
    }
}