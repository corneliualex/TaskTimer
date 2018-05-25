using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskTimer.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace TaskTimer.Services.Repository
{
    public class ActivityRepository : IEntityRepository<Activity>
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private DbSet<Activity> _activityDbSet;
        //construcotor : init _activityDbSet with _context.Activities
        public ActivityRepository()
        {
            _activityDbSet = _context.Activities;
        }

        //create activity
        public void Create(Activity activity)
        {
            activity.ApplicationUserId = HttpContext.Current.User.Identity.GetUserId();
            _activityDbSet.Add(activity);
            _context.SaveChanges();
        }

        //delete activity
        public bool Delete(int? id)
        {
            if (GetById(id) == null) return false;

            _activityDbSet.Remove(GetById(id));
            _context.SaveChanges();
            return true;

        }

        //get activity by id
        public Activity GetById(int? id)
        {
            if (id == null) return null;

            return _activityDbSet.Include(u => u.ApplicationUser).Include(c => c.Category).SingleOrDefault(a => a.Id == id);
        }

        //get all activites
        public IEnumerable<Activity> GetAll()
        {
            return _activityDbSet.Include(u => u.ApplicationUser).Include(c => c.Category).ToList();
        }      

        //edit activity
        public bool Edit(Activity activity)
        {
            if (activity == null) return false;

            var activityInDb = GetById(activity.Id);
            if (activityInDb == null) return false;

            activityInDb.Id = activity.Id;
            activityInDb.Description = activity.Description;
            activityInDb.Date = activity.Date;
            activityInDb.TimeSpent = activity.TimeSpent;
            activityInDb.ApplicationUserId = activity.ApplicationUserId;
            activityInDb.CategoryId = activity.CategoryId;

            _context.SaveChanges();
            return true;           
        }
    }
}