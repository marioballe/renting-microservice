using System;
using System.Threading.Tasks;

namespace RentingMicroservice.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}