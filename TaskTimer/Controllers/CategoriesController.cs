using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskTimer.Models;
using TaskTimer.Services.Repository;

namespace TaskTimer.Controllers
{
    public class CategoriesController : Controller
    {
        private IEntityRepository<Category> _categoriesRepository = new CategoryRepository();

        public ActionResult Index()
        {
            var categories = _categoriesRepository.GetAll();
            if (categories == null) return HttpNotFound();

            return View(categories);
        }

        public ActionResult Details(int? id)
        {
            var category = _categoriesRepository.GetById(id);
            if (category == null) return HttpNotFound();

            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (_categoriesRepository.Delete(id) == false) return HttpNotFound();

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            return View("CategoryForm", new Category());
        }

        public ActionResult Save(Category category)
        {
            if (category.Id == 0) _categoriesRepository.Create(category);
            
            else if (_categoriesRepository.Edit(category) == false) return HttpNotFound();

            return RedirectToAction("Index", "Categories");
        }

        public ActionResult Edit(int? id)
        {
            var category = _categoriesRepository.GetById(id);
            if (_categoriesRepository.Edit(category) == false) return HttpNotFound();

            return View("CategoryForm", category);
        }
    }
}