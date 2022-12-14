using ileriRepository.Repositories.Abstract;

namespace ileriRepository.UnitofWork
{
    public interface IUnit
    {
        IPersonelRep _personelRep { get;  }
        IGradeRep _gradeRep { get;  }
        IDepartmentRep _departmentRep { get; }
        ICountyRep _countyRep { get; }
        ICityRep _cityRep { get; }

        void Commit();
    }
}
