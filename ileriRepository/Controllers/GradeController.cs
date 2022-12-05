using ileriRepository.Data;
using ileriRepository.Models;
using ileriRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;

namespace ileriRepository.Controllers
{
    public class GradeController : Controller
    {
        IUnit _uow;
        GradeModel _model;
        public GradeController(IUnit uow, GradeModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uow._gradeRep.List();
            return View(clist);
        }
        public IActionResult Create()
        {
            _model.Head = "Create New";
            _model.Text = "Save";
            _model.Cls = "btn btn-primary";
            _model.Grade = new Grade();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Create(GradeModel gm)
        {

            _uow._gradeRep.Add(gm.Grade);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Delete(string Id)
        {
            _model.Head = "Delete";
            _model.Text = "OK";
            _model.Cls = "btn btn-danger";
            _model.Grade = _uow._gradeRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(GradeModel model)
        {

            _uow._gradeRep.Delete(model.Grade);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Update(string Id)
        {
            _model.Head = "Update";
            _model.Text = "OK";
            _model.Cls = "btn btn-success";
            _model.Grade = _uow._gradeRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Update(GradeModel g)
        {
            _uow._gradeRep.Update(g.Grade);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}

