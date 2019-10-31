using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.PeopleService
{
    public class PeopleService
    {
        private readonly Assgn10Context _assgn10Context;

        public PeopleService(Assgn10Context assgn10Context)
        {
            _assgn10Context = assgn10Context;
        }

        public bool DoesPersonExist(int id)
        {
            var person = _assgn10Context.People.Find(id);

            if (person == null)
            {
                return false;
            }

            return !person.IsDeleted;
        }

        public Ch10CreatePersonModel Assgn10PersonDetailModel()
        {
            var person = _assgn10Context.People
         //                            .Where(x => x.!IsDeleted)
                                     .Select(x => new Ch10CreatePersonModel
                                     {
                                         id = x.id,
                                         FirstName = x.FirstName,
                                         LastName = x.LastName,
                                         BirthDate = x.BirthDate,
                                         City = x.City,
                                         State = x.State,
                                         SetOfAccomplishments = x.SetOfAccomplishments

                                     })
                                     .SingleOrDefault();
            return person;
        }

        public void CreatePeople(int id, UpdatePeopleCommand command)
        {

            var person = _assgn10Context.People.Find(id);

            if (person == null)
            {
                throw new Exception("Unable to find Person");
            }

            person.FirstName = command.FirstName;
            person.LastName = command.LastName;
            person.BirthDate = command.BirthDate;
            person.City = command.City;
            person.State = command.State;
            person.SetOfAccomplishments = command.SetOfAccomplishments;

            _assgn10Context.SaveChanges();
        }
    }
}
