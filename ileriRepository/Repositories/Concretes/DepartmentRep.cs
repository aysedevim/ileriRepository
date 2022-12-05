using ileriRepository.Context;
using ileriRepository.Core;
using ileriRepository.Data;
using ileriRepository.Repositories.Abstract;

namespace ileriRepository.Repositories.Concretes
{
    public class DepartmentRep<T> : BaseRepository<Department>, IDepartmentRep where T : class
    {
        public DepartmentRep(MyContext db) : base(db)
        {
        }
    }
}
