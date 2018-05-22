using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTimer.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //FK + nav prop => one to many relation
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //FK + nav prop => one to many relation
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}