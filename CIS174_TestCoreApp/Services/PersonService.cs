using CIS174_TestCoreApp.Entity;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Services
{
    public class PersonService: IPersonService
    {
        private readonly Assgn10Context _assgn10Context;
        public PersonService(Assgn10Context assgn10Context)
        {
            _assgn10Context = assgn10Context;
        }


        public ICollection<Ch10SummaryModel> Ch10SummryView()
        {
            return _assgn10Context.People
                .Where(r => !r.IsDeleted)
                .Select(x => new Ch10SummaryModel
                {
                    //         id = x.id,
                    Summary_Name = x.FirstName,
      //              Summary_No_Accompliments = x.SetOfAccomplishments,
                })
                .ToList();
        }

        //******** above here ********


        
        public bool DoesPersonExist(int id)
        {
            var person = _assgn10Context.People.Find(id);

            if (person == null)
            {
                return false;
            }

            return !person.IsDeleted;
        }

        public PersonCreateCommandModel Create(PersonCreateCommandModel cmd)
        {
            var model = new Assgn10Person
                        {
                            FirstName = cmd.FirstName,
                            LastName = cmd.LastName,
                            BirthDate = cmd.BirthDate,
                            City = cmd.City,
                            State = cmd.State,
                            IsDeleted = false,
                        };

            _assgn10Context.People.Add(model);
            _assgn10Context.SaveChanges();
            return cmd;
        }

        public void CreatePeople(int id,UpdatePeopleCommand command)
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
   //         person.SetOfAccomplishments = command.SetOfAccomplishments;

            _assgn10Context.SaveChanges();
        }

        public void DBLogEntry(string value)
        {
            // write logtime to database Using *** logEntry** to identify log entry
            // and Isdeleted as true

            var logTime = value;
            var person = _assgn10Context.People
                                     //  .Where(x => !IsDeleted)
                                     .Select(x => new Ch10CreateNewPersonModel
                                     {
                                         id = x.id,
                                         FirstName = "**Log Entry**",
                                         LastName = value,
                                         IsDeleted = true

                                     });
            _assgn10Context.Add(person);
            _assgn10Context.SaveChanges();


        }

        public void LogRequest(PersonCreateCommandModel cmd)
        {
            DateTime currentDate = DateTime.Now;
            var model = new Assgn10Person
            {
                FirstName = "**Logging**",
                LastName = "**Access API**",
                BirthDate = currentDate,
                City = "*********",
                State = "********",
                IsDeleted = false,
            };

            _assgn10Context.People.Add(model);
            _assgn10Context.SaveChanges();
            
        }

        public void LogRequest()
        {
            throw new NotImplementedException();
        }
    }
}
