namespace EmployeeRegistratation.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Save(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}