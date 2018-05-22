using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskTimer.Models;
using TaskTimer.Services.Repository;
using System.Data.Entity;

namespace TaskTimer.Services.Repository
{
    public class ActivityRepository : IEntityRepository<Activity>
    {
        public bool Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Activity GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Activity t)
        {
            throw new NotImplementedException();
        }
    }
}