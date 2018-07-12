using System;

namespace BookStoreData.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DatNguyenBookStoreDBContext Init();
    }
}
