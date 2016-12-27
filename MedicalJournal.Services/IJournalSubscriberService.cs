namespace MedicalJournal.Service
{
    using Core.Data;
    using System.Linq;
    public interface IJournalSubscriberService
    {
        IQueryable<JournalSubscriber> GetTypes();
        JournalSubscriber GetType(long id);
        void InsertType(JournalSubscriber user);
        void DeleteType(JournalSubscriber user);
    }
}
