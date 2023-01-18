using ConEmployeeRegistratationtatos.Domain.Interfaces;
using EmployeeRegistratation.Context.Persistence;

namespace EmployeeRegistratation.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeContext _context;

        public UnitOfWork(EmployeeContext context)
        {
            _context = context;
        }

        public void Commit()
        {
             _context.SaveChangesAsync();
        }
    }
}