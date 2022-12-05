using ileriRepository.Context;
using ileriRepository.Core;
using ileriRepository.Data;
using ileriRepository.Repositories.Abstract;

namespace ileriRepository.Repositories.Concretes
{
    public class CountyRep<T> : BaseRepository<County>, ICountyRep where T : class
    {
        public CountyRep(MyContext db) : base(db)
        {
        }
    }
}
