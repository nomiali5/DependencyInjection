namespace MedicalJournal.Service
{
    using Core.Data;
    using MedicalJournal.Data;
    using System.Linq;
    public class JournalSubscriberService : IJournalSubscriberService
    {
        private IRepository<JournalSubscriber> journalSubscriberRepository;

        public JournalSubscriberService(IRepository<JournalSubscriber> JournalSubscriberRepository)
        {
            this.journalSubscriberRepository = JournalSubscriberRepository;
        }

        public IQueryable<JournalSubscriber> GetTypes()
        {
            return journalSubscriberRepository.Table;
        }

        public JournalSubscriber GetType(long id)
        {
            return journalSubscriberRepository.GetById(id);
        }

        public void InsertType(JournalSubscriber JournalSubscriber)
        {
            journalSubscriberRepository.Insert(JournalSubscriber);
        }

        public void DeleteType(JournalSubscriber JournalSubscriber)
        {
            journalSubscriberRepository.Delete(JournalSubscriber);
        }
    }
}
