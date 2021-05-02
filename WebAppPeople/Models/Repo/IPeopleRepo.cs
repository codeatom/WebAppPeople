using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPeople.Models.Data;

namespace WebAppPeople.Models.Repo
{
    interface IPeopleRepo
    {
        Person Create(Person person);
        Person Read(int id); //Find by Id
        List<Person> Read(); //Get all
        Person Update(Person person);
        bool Delete(int id);
    }
}
