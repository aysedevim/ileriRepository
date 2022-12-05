using ileriRepository.Core;
using ileriRepository.Data;

namespace ileriRepository.Repositories.Abstract
{
    public interface IGradeRep : IBaseRepository<Grade>
    {
        Grade Find(string ıd);
    }
}
