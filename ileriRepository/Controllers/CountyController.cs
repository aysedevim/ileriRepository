using ileriRepository.Data;
using ileriRepository.Models;
using ileriRepository.DTO;
using ileriRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;

namespace ileriRepository.Controllers
{
    public class CountyController : Controller
    {
        IUnit _uow;
        CountyModel _model;
        public CountyController(IUnit uow, CountyModel model)
        {
        _uow= uow;
        _model= model;
        }
        public IActionResult List()
        {
            var cList = _uow._countyRep.Set().Select(x => new CountyDTO
            {
                Id = x.Id,
                CountyName = x.CountyName,
                CityName = x.City.CityName,
            }).ToList();
            //var clist = _uow._countyRep.List();
            return View(cList);
        }
        public IActionResult Create()
        {
            _model.Head = "Create New";
            _model.Text = "Save";
            _model.Cls = "btn btn-primary";
            _model.County = new County();
            _model.Cities = _uow._cityRep.List();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Create(CountyModel m)
        {

            _uow._countyRep.Add(m.County);
            _uow.Commit();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Head = "Delete";
            _model.Text = "OK";
            _model.Cls = "btn btn-danger";
            _model.County = _uow._countyRep.Find(Id);
            _model.Cities = _uow._cityRep.List();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(County c)
        {

            _uow._countyRep.Delete(c);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Update(int Id)
        {
            _model.Head = "Update";
            _model.Text = "OK";
            _model.Cls = "btn btn-success";
            _model.County = _uow._countyRep.Find(Id);
            _model.Cities = _uow._cityRep.List();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Update(CountyModel model)
        {
            _uow._countyRep.Update(model.County);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
