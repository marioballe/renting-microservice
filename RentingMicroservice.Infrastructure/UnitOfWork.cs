using RentingMicroservice.Domain.Interfaces;

namespace RentingMicroservice.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoDbContext _dbContext;

        public UnitOfWork(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Task.FromResult(0);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}