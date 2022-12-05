using Microsoft.EntityFrameworkCore;

namespace ileriRepository.Core
{
    public interface IBaseRepository<T> where T : class //generic değişken
    {
        public List<T> List();
        public T Find(int Id);
        public bool Update(T entity);
        public bool Delete(T entity);
        public bool Add(T entity);
        public DbSet<T> Set();
        

    }
}
