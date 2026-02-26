using UnitOfWork.Models;
using UnitOfWork.Repositories;
using System;
using System.Threading.Tasks;

namespace UnitOfWork.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Producto> Productos { get; }
        Task<int> CompleteAsync();
    }
}