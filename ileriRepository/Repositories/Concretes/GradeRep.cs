using ileriRepository.Context;
using ileriRepository.Core;
using ileriRepository.Data;
using ileriRepository.Repositories.Abstract;

namespace ileriRepository.Repositories.Concretes
{
    public class GradeRep<T> : BaseRepository<Grade>, IGradeRep where T : class
    {
        public GradeRep(MyContext db) : base(db)
        {
        }
    }
}
