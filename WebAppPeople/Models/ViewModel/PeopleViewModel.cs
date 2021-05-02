using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPeople.Models.ViewModel
{
    public class PeopleViewModel
    {
        public PersonViewModel MyPersonViewModel { get; set; }
        public CreatePerson MyCreatePerson { get; set; }

        public PeopleViewModel()
        {
            MyPersonViewModel = new PersonViewModel();
            MyCreatePerson = new CreatePerson();
        }
    }
}
