using bulkybkwp.Models;

namespace bulkybkw.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
        
    }
}
