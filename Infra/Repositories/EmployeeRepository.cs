using EmployeeRegistratation.Context.Persistence;
using EmployeeRegistratation.Domain.Entities;

namespace EmployeeRegistratation.Infra.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        { }

        public override Employee GetById(int id)
        {
            var query = _context.Set<Employee>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Employee> GetAll()
        {
            var query = _context.Set<Employee>();

            return query.Any() ? query.ToList() : new List<Employee>();
        }
    }
}