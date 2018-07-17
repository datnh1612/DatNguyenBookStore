using BookStoreData.Infrastructure;
using BookStoreModel.Models;

namespace BookStoreData.Repositories
{
    public interface ISlideRepository : IRepository<Slide>
    {
    }

    public class SlideRepository : RepositoryBase<Slide>,ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
