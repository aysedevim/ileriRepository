using ileriRepository.Context;
using ileriRepository.Core;
using ileriRepository.Data;
using ileriRepository.Repositories.Abstract;

namespace ileriRepository.Repositories.Concretes
{
    public class CityRep<T> : BaseRepository<City>, ICityRep where T : class
    {
        public CityRep(MyContext db) : base(db)
        {
        }
    }
}
