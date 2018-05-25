using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskTimer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Activity> Activities { get; set; }

        //not mapped properties by ef
        [NotMapped]
        public string Title
        {
            get { return Id == 0 ? "New" : "Edit"; }
        }
    }
}