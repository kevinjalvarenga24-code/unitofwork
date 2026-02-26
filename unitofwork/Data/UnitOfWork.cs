using UnitOfWork.Models;
using UnitOfWork.Repositories;
using System.Threading.Tasks;

namespace UnitOfWork.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplicacionDbContext _context;
        public IGenericRepository<Producto> Productos { get; private set; }

        public UnitOfWork(AplicacionDbContext context)
        {
            _context = context;
            Productos = new GenericRepository<Producto>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}