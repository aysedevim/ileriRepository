using ileriRepository.Data;
using ileriRepository.Models;
using ileriRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;

namespace ileriRepository.Controllers
{
    public class DepartmentController : Controller
    {
        IUnit _uow;
        DepartmentModel _model;
        public DepartmentController(IUnit uow, DepartmentModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uow._departmentRep.List();
            return View(clist);
        }
        public IActionResult Create()
        {
            _model.Head = "Create New";
            _model.Text = "Save";
            _model.Cls = "btn btn-primary";
            _model.Department = new Department();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Create(DepartmentModel dm)
        {

            _uow._departmentRep.Add(dm.Department);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Delete";
            _model.Text = "OK";
            _model.Cls = "btn btn-danger";
            _model.Department = _uow._departmentRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentModel model)
        {

            _uow._departmentRep.Delete(model.Department);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Update(int Id)
        {
            _model.Head = "Update";
            _model.Text = "OK";
            _model.Cls = "btn btn-success";
            _model.Department = _uow._departmentRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Update(DepartmentModel d)
        {
            _uow._departmentRep.Update(d.Department);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
      
