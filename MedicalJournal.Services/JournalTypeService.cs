namespace MedicalJournal.Service
{
    using Core.Data;
    using MedicalJournal.Data;
    using System.Linq;
    public class JournalTypeService : IJournalTypeService
    {
        private IRepository<JournalType> JournalTypeRepository;

        public JournalTypeService(IRepository<JournalType> journalTypeRepository)
        {
            this.JournalTypeRepository = journalTypeRepository;
        }

        public IQueryable<JournalType> GetTypes()
        {
            return JournalTypeRepository.Table;
        }

        public JournalType GetType(long id)
        {
            return JournalTypeRepository.GetById(id);
        }

        public void InsertType(JournalType JournalType)
        {
            JournalTypeRepository.Insert(JournalType);
        }

        public void UpdateType(JournalType JournalType)
        {
            JournalTypeRepository.Update(JournalType);
        }

        public void DeleteType(JournalType JournalType)
        {
            JournalTypeRepository.Delete(JournalType);
        }
    }
}
