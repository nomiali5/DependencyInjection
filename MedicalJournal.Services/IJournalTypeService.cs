namespace MedicalJournal.Service
{
    using Core.Data;
    using System.Linq;
    public interface IJournalTypeService
    {
        IQueryable<JournalType> GetTypes();
        JournalType GetType(long id);
        void InsertType(JournalType user);
        void UpdateType(JournalType user);
        void DeleteType(JournalType user);
    }
}
