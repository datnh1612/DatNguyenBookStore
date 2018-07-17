using BookStoreData.Infrastructure;
using BookStoreModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreData.Repositories
{
    public interface IErrorRepository : IRepository<Error>
    {

    }
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
