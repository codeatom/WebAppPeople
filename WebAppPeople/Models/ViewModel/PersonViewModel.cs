using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPeople.Models.Data;

namespace WebAppPeople.Models.ViewModel
{
    public class PersonViewModel
    {
        public string FilterText { get; set; }
        public List<Person> PersonList { get; set; }
    }
}