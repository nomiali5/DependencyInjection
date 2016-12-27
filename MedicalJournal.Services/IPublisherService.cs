namespace MedicalJournal.Service
{
    using Core.Data;
    using System.Linq;
    public interface IPublisherService
    {
        IQueryable<Publisher> GetPublishers();
        Publisher GetPublisher(long id);
        void InsertPublisher(Publisher user);
        void UpdatePublisher(Publisher user);
        void DeletePublisher(Publisher user);
    }
}
