using BookAppSolution.DataAccess.Data;
using BookAppSolution.DataAccess.Repository.IRepository;
using BookAppSoultion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAppSolution.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(CoverType obj)
        {
            db.CoverTypes.Update(obj);
        }
    }
}
