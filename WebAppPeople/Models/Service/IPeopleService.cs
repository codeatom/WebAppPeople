using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPeople.Models.Data;
using WebAppPeople.Models.ViewModel;

namespace WebAppPeople.Models.Service
{
    interface IPeopleService
    {
        Person Add(CreatePerson createPerson);
        PersonViewModel All();
        Person FindById(int id);
        List<Person> FindByKeyWord(string names);
        Person Edit(int id, CreatePerson car);
        CreatePerson PersonToCreatePerson(Person person);
        bool Remove(int id);
    }
}
