namespace BookStoreData.Infrastructure
{
    public class DbFactory: Dispoable, IDbFactory
    {
        private DatNguyenBookStoreDBContext dbContext;

        public DatNguyenBookStoreDBContext Init()
        {
            return dbContext ?? (dbContext = new DatNguyenBookStoreDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
