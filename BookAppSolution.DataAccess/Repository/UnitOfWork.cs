using BookAppSolution.DataAccess.Data;
using BookAppSolution.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAppSolution.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;

        public UnitOfWork(ApplicationDbContext db)
        { 
            this.db = db;
            Category = new CategoryRepository(db);
            CoverType = new CoverTypeRepository(db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
