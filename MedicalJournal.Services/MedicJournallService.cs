namespace MedicalJournal.Service
{
    using Core.Data;
    using MedicalJournal.Data;
    using System.Linq;
    public class MedicJournallService : IMedicJournallService
    {
        private IRepository<MedicJournal> MedicJournalRepository;

        public MedicJournallService(IRepository<MedicJournal> userRepository)
        {
            this.MedicJournalRepository = userRepository;
        }

        public IQueryable<MedicJournal> GetJournals()
        {
            return MedicJournalRepository.Table;
        }

        public MedicJournal GetJournal(long id)
        {
            return MedicJournalRepository.GetById(id);
        }

        public void InsertJournal(MedicJournal MedicJournal)
        {
            MedicJournalRepository.Insert(MedicJournal);
        }

        public void UpdateJournal(MedicJournal MedicJournal)
        {
            MedicJournalRepository.Update(MedicJournal);
        }

        public void DeleteJournal(MedicJournal MedicJournal)
        {
            MedicJournalRepository.Delete(MedicJournal);
        }
    }
}
