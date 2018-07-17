using BookStoreData.Infrastructure;
using BookStoreModel.Models;

namespace BookStoreData.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
