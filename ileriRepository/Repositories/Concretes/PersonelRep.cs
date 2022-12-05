using ileriRepository.Context;
using ileriRepository.Core;
using ileriRepository.Data;
using ileriRepository.DTO;
using ileriRepository.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ileriRepository.Repositories.Concretes
{
    public class PersonelRep<T> : BaseRepository<Personel>, IPersonelRep where T:class //personel için kullanılacak tüm metotlar burada... (BaseRepository<Personel> + IPersonelRep)
    {
        public PersonelRep(MyContext db) : base(db)
        {
           
        }
        public Personel FindDetail(int Id)
        {
            return Set().Include(x=>x.County).ThenInclude(x=>x.City).Include(x=>x.Department).FirstOrDefault(x => x.Id == Id); // Include ile county e ulaşır ThenInclude ile County- City ID den city e ulaşır.
        }
        public string Fullname(Personel p) //personele ait bilgiler Personel.cs de olduğundan bu metotları orada tanımladık.
        {
            return p.Fullname();
        }

        public List<string> GetAddress(Personel p)
        {
            return p.GetAddress();
        }

        public int GetAge(Personel p)
        {
            return p.GetAge();
        }

        public List<PersonelDepList> ListbyDepartment()
        {
            return Set().Select(x => new PersonelDepList
            {
                Id = x.Id,
                Department = x.Department.DepartmentName,
                FullName = x.Name + " " + x.SurnameName,
                ImgUrl = x.ImgUrl,
            }).OrderBy(x => x.FullName).ToList();

    
            
        }

        public List<PersonelGradeList> ListbyGrade()
        {
            return Set().Select(x => new PersonelGradeList
            {
                Id = x.Id,
                Grade = x.Grade.GradeName,
                GradeId = x.GradeId,
                FullName = x.Name + " " + x.SurnameName,
                ImgUrl = x.ImgUrl,
            }).OrderBy(x => x.GradeId).ToList();

        }
    }
}
