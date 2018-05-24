using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskTimer.Models;

namespace TaskTimer.Services.Repository
{
    public class CategoryRepository : IEntityRepository<Category>
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public Category GetById(int? id)
        {
            if (id == null) return null;

            return _context.Categories.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public bool Delete(int? id)
        {
            if (GetById(id) == null) return false;

            _context.Categories.Remove(GetById(id));
            _context.SaveChanges();
            return true;
        }

        public bool Edit(Category category)
        {
            if (category == null) return false;

            var categoryInDb = GetById(category.Id);
            if (categoryInDb == null) return false;

            categoryInDb.Id = category.Id;
            categoryInDb.Name = category.Name;

            _context.SaveChanges();
            return true;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}