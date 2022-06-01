using BookAppSolution.DataAccess.Data;
using BookAppSolution.DataAccess.Repository.IRepository;
using BookAppSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAppSolution.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(Category obj)
        {
            db.Categories.Update(obj);
        }
    }
}
