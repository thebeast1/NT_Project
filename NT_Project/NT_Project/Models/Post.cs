using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string PostMessage { get; set; }
        public DateTime? PostDate { get; set; }
        public ICollection<string> Photos { get; set; }
        public ICollection<string> Videos { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [NotMapped]
        public string Name { get; set; }
    }
}