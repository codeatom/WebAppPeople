using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPeople.Models.Data;
using WebAppPeople.Models.Service;
using WebAppPeople.Models.ViewModel;

namespace WebAppPeople.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService = new PeopleService();

        [HttpGet]
        public IActionResult Index()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.MyPersonViewModel = _peopleService.All();

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            string searchString = peopleViewModel.MyPersonViewModel.FilterText;
            List<Person> filteredPersons = _peopleService.FindByKeyWord(searchString);
            peopleViewModel.MyPersonViewModel.PersonList = filteredPersons;

            ModelState.Clear();
            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePerson MyCreatePerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(MyCreatePerson);

                return RedirectToAction(nameof(Index));
            }

            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.MyPersonViewModel = _peopleService.All();
            peopleViewModel.MyCreatePerson = MyCreatePerson;

            return View("Index", peopleViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            EditPerson editPerson = new EditPerson();
            editPerson.Id = id;
            editPerson.CreatePerson = _peopleService.PersonToCreatePerson(person);

            return View(editPerson);
        }

        [HttpPost]
        public IActionResult Edit(int id, CreatePerson createPerson)
        {
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Edit(id, createPerson);
                return RedirectToAction(nameof(Index));
            }

            EditPerson editPerson = new EditPerson();
            editPerson.Id = id;
            editPerson.CreatePerson = createPerson;

            return View(editPerson);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            _peopleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
