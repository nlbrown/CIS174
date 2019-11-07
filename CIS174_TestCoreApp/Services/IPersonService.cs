using CIS174_TestCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Services
{
    public interface IPersonService
    {
        ICollection<Ch10SummaryModel> Ch10SummryView();
        bool DoesPersonExist(int id);
        PersonCreateCommandModel Create(PersonCreateCommandModel cmd);
        void CreatePeople(int id, UpdatePeopleCommand command);
        void LogRequest();
    }
}
