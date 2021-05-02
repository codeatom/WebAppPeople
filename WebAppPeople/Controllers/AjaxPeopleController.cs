using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPeople.Models.Data;
using WebAppPeople.Models.Service;

namespace WebAppPeople.Controllers
{
    public class AjaxPeopleController : Controller
    {
        IPeopleService _peopleService = new PeopleService();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DisplayPeople()
        {
            List<Person> persons = _peopleService.All().PersonList;

            if (persons.Count != 0)
            {
                return PartialView("_PeoplePartialView", _peopleService.All().PersonList);
            }

            return Ok("There is no person in the list");  
        }

        [HttpPost]
        public IActionResult DisplayPerson(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person != null)
            {
                return PartialView("_PersonPartialView", _peopleService.FindById(id));
            }

            return Ok("There is no person with id " + id);
        }

        [HttpPost]
        public IActionResult RemovePerson(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person != null)
            {
                _peopleService.Remove(id);
                return Ok("Person with id " + id + " removed.");
            }

            return Ok("There is no person with id " + id);
        }
    }
}
