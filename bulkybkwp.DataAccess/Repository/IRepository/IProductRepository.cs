using bulkybkwp.Models;

namespace bulkybkw.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        
    }
}
