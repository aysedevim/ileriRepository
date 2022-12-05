using ileriRepository.Core;
using ileriRepository.Data;
using ileriRepository.DTO;

namespace ileriRepository.Repositories.Abstract
{
    public interface IPersonelRep:IBaseRepository<Personel> //ek metotların tanımı yapılacak.
    {
        public int GetAge(Personel p);
        public string Fullname(Personel p);
        List<string> GetAddress(Personel p);

        Personel FindDetail(int Id);
        List<PersonelGradeList> ListbyGrade();

        List<PersonelDepList> ListbyDepartment();
    }
}
