using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppPeople.Models.Data;
using WebAppPeople.Models.Repo;
using WebAppPeople.Models.ViewModel;

namespace WebAppPeople.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo; //storage for Person data

        public PeopleService()
        {
            _peopleRepo = new PeopleRepo();
        }

        public Person Add(CreatePerson createPerson)
        {
            Person person = new Person();

            person.FirstName = createPerson.FirstName;
            person.LastName = createPerson.LastName;
            person.CurrentCity = createPerson.CurrentCity;
            person.CellphoneNumber = createPerson.CellphoneNumber;

            person = _peopleRepo.Create(person);

            return person;
        }

        public PersonViewModel All()
        {
            PersonViewModel PersonViewModel = new PersonViewModel();
            PersonViewModel.PersonList = _peopleRepo.Read();

            return PersonViewModel;
        }

        public Person FindById(int id)
        {
            return _peopleRepo.Read(id);
        }

        public List<Person> FindByKeyWord(string keyWord)
        {
            List<Person> personList = new List<Person>();

            string searchStr = "";
            string currentCity = "";
            string firstName = "";
            string lastName = "";
            string fullName = "";

            if (string.IsNullOrWhiteSpace(keyWord))
            {
                return personList;
            }
            else
            {
                searchStr = keyWord.ToLower().Replace(" ", "");
            }

            foreach (Person item in _peopleRepo.Read())
            {
                currentCity = item.CurrentCity.ToLower();
                firstName = item.FirstName.ToLower();
                lastName = item.LastName.ToLower();

                fullName = firstName + lastName;

                if (fullName.Equals(searchStr) ||
                    currentCity.Equals(searchStr) ||
                    firstName.Equals(searchStr) ||
                    lastName.Equals(searchStr))
                {
                    personList.Add(item);
                }
            }

            return personList;
        }

        public Person Edit(int id, CreatePerson createPerson)
        {
            Person originalPerson = FindById(id);

            if (originalPerson == null)
            {
                return null;
            }

            originalPerson.FirstName = createPerson.FirstName;
            originalPerson.LastName = createPerson.LastName;
            originalPerson.CurrentCity = createPerson.CurrentCity;
            originalPerson.CellphoneNumber = createPerson.CellphoneNumber;

            originalPerson = _peopleRepo.Update(originalPerson);

            return originalPerson;
        }

        public CreatePerson PersonToCreatePerson(Person person)
        {
            CreatePerson createPerson = new CreatePerson();

            createPerson.FirstName = person.FirstName;
            createPerson.LastName = person.LastName;
            createPerson.CurrentCity = person.CurrentCity;
            createPerson.CellphoneNumber = person.CellphoneNumber;

            return createPerson;
        }

        public bool Remove(int id)
        {
            return _peopleRepo.Delete(id);
        }
    }
}
