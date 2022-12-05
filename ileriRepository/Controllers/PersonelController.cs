using ileriRepository.Context;
using ileriRepository.Data;
using ileriRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;

namespace ileriRepository.Controllers
{
    public class PersonelController : Controller
    {
        IUnit _unit;
        public PersonelController(IUnit unit)
        {
            _unit = unit;
        }
        public IActionResult ListGrade() //Liste Grade e göre sıralanır...
        {
            
            return View(_unit._personelRep.ListbyGrade());
        }
        public IActionResult Details(int Id)
        {
            Personel p = _unit._personelRep.FindDetail(Id);
            return View(p);
        }

        public IActionResult ListDep()
        {
            return View(_unit._personelRep.ListbyDepartment());
        }
    }
}
