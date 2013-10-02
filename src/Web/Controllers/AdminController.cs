using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        private IPersonRepository _repository;

        public AdminController()
        {
            _repository = PersonRepository.Instance;
        }

        public ActionResult Search()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public JsonResult Search(SearchViewModel model)
        {
            model.Results = _repository.FindAll();
            
            return Json(model);
        }

        public ActionResult Details(int id)
        {
            return View(_repository.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            _repository.Create(person);
        
            return RedirectToAction("Search");
        }

        public ActionResult Edit(int id)
        {
            return View(_repository.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            _repository.Save(person);

            return RedirectToAction("Search");
        }
    }
}