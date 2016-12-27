namespace MedicalJournal.Service
{
    using MedicalJournal.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPubService
    {
        IQueryable<ApplicationUser> GetPublishers();
        ApplicationUser GetPublisher(string id);
        void InsertPublisher(ApplicationUser user);
        void UpdatePublisher(ApplicationUser user);
        void DeletePublisher(ApplicationUser user);
    }
}
