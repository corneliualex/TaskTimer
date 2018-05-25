using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskTimer.Models;
using System.Data.Entity;
using TaskTimer.Services.Repository;
using TaskTimer.ViewModels;

namespace TaskTimer.Controllers
{
    public class ActivitiesController : Controller
    {
        private IEntityRepository<Activity> _activityRepository = new ActivityRepository();
        private IEntityRepository<Category> _categoryRepository = new CategoryRepository();
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Activities
        public ActionResult Index()
        {
            var activity = _activityRepository.GetAll();
            if (activity == null) return HttpNotFound();

            return View(activity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();

            var activity = _activityRepository.GetById(id);
            if (activity == null) return HttpNotFound();

            return View(activity);
        }

        public ActionResult New()
        {
            var viewModel = new ActivityCategoriesViewModel()
            {
                Categories = _categoryRepository.GetAll()
            };

            return View("ActivityForm", viewModel);
        }

        public ActionResult Edit(int? id)
        {
            var activity = _activityRepository.GetById(id);
            if (activity == null) return HttpNotFound();

            var viewModel = new ActivityCategoriesViewModel(activity)
            {
                Categories = _categoryRepository.GetAll()
            };

            return View("ActivityForm", viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var activity = _activityRepository.Delete(id);
            if (activity == false) return HttpNotFound();

            return RedirectToAction("Index", "Activities");
        }

        [HttpPost]
        public ActionResult Save(Activity activity)
        {

            if (activity.Id == 0) _activityRepository.Create(activity);

            else if (_activityRepository.Edit(activity) == false) return HttpNotFound();

            return RedirectToAction("Index", "Activities");
        }
    }
}