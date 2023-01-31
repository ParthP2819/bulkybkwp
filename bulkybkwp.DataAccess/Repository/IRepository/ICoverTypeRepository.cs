using bulkybkwp.Models;

namespace bulkybkw.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType obj);
        
    }
}
