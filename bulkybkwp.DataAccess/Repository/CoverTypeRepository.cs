using bulkybkw.DataAccess.Repository;
using bulkybkw.DataAccess.Repository.IRepository;
using bulkybkwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulkybkwp.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(CoverType obj)
        {
            _db.covertypes.Update(obj);
        }
    }
}
