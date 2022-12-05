using ileriRepository.Data;
using ileriRepository.Models;
using ileriRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace ileriRepository.Controllers
{
    public class CityController : Controller
    {
        IUnit _uow;
        CityModel _model;
        public CityController(IUnit uow,CityModel model)
        {
            _uow= uow;
            _model= model;
        }
        public IActionResult List()
        {
           var clist= _uow._cityRep.List();
            return View(clist);
        }

        public IActionResult Create()
        {
            _model.Head = "Create New";
            _model.Text = "Save";
            _model.Cls = "btn btn-primary";
            _model.City = new City();
            return View("Crud",_model);
        }
     
        [HttpPost]
        public IActionResult Create(CityModel m)
        {

            _uow._cityRep.Add(m.City);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Delete";
            _model.Text = "OK";
            _model.Cls = "btn btn-danger";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud",_model);
        }
        [HttpPost]
        public IActionResult Delete(CityModel model)
        {

            _uow._cityRep.Delete(model.City);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Update(int Id)
        {
            _model.Head = "Update";
            _model.Text = "OK";
            _model.Cls = "btn btn-success";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Update(CityModel c)
        {
            _uow._cityRep.Update(c.City);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
