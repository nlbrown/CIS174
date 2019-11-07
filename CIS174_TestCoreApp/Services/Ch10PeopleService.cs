using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Services
{
    public class Ch10PeopleService
    {
        private readonly Assgn10Context _assgn10Context;

        public ICollection<Ch10SummaryModel> Ch10SummryView()
        {
            return _assgn10Context.People
                .Where(r => !r.IsDeleted)
                .Select(x => new Ch10SummaryModel
                {
                    //         id = x.id,
                    Summary_Name = x.FirstName,
                    Summary_No_Accompliments = x.SetOfAccomplishments,
                })
                .ToList();
        }

        //******** above here ********


        public Ch10PeopleService(Assgn10Context assgn10Context)
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

        public int Create([FromBody]UpdatePeopleCommand cmd)
        {
            var person = _assgn10Context.People
                                     //  .Where(x => !IsDeleted)
                                     .Select(x => new Ch10CreatePersonViewModel
                                     {
                                         id = x.id,
                                         FirstName = x.FirstName,
                                         LastName = x.LastName,
                                         BirthDate = x.BirthDate,
                                         City = x.City,
                                         State = x.State,
                                         IsDeleted = false,
                                         SetOfAccomplishments = x.SetOfAccomplishments

                                     })
                                     .SingleOrDefault();

            _assgn10Context.SaveChanges();
            return person.id;
        }

        public void CreatePeople(int id, [FromBody] UpdatePeopleCommand command)
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

        public void DBLogEntry(string value)
        {
            // write logtime to database Using *** logEntry** to identify log entry
            // and Isdeleted as true

            var logTime = value;
            var person = _assgn10Context.People
                                     //  .Where(x => !IsDeleted)
                                     .Select(x => new Ch10CreatePersonViewModel
                                     {
                                         id = x.id,
                                         FirstName = "**Log Entry**",
                                         LastName = value,
                                         IsDeleted = true

                                     });
            _assgn10Context.SaveChanges(); 


        }
    }
}
