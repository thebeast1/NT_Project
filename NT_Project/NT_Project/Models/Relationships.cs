using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NT_Project.Models
{
    public class Relationships
    {
        public int id { get; set; }
        public int friend_id { get; set; }
        public ApplicationUser user{ get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? date_of_friendship { get; set; }
        public int? status { get; set; }
        

    }
}