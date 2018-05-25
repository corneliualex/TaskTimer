using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskTimer.Models;

namespace TaskTimer.ViewModels
{
    public class ActivityCategoriesViewModel
    {
        //public Activity Activity { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        //Instead of getting a Activity object

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime? Date { get; set; }
        public DateTime? TimeSpent { get; set; }

        public int CategoryId { get; set; }

        public string ApplicationUserId { get; set; }

        public string Title
        {
            get { return Id == 0 ? "New" : "Edit"; }
        }
        public ActivityCategoriesViewModel()
        {
            Id = 0;
        }

        public ActivityCategoriesViewModel(Activity activity)
        {
            Id = activity.Id;
            Description = activity.Description;
            Date = activity.Date;
            TimeSpent = activity.TimeSpent;
            CategoryId = activity.CategoryId;
            ApplicationUserId = activity.ApplicationUserId;
        }
    }
}