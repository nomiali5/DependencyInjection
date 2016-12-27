namespace MedicalJournal.Service
{
    using Core.Data;
    using System.Linq;
    public interface IMedicJournallService
    {
        IQueryable<MedicJournal> GetJournals();
        MedicJournal GetJournal(long id);
        void InsertJournal(MedicJournal journal);
        void UpdateJournal(MedicJournal journal);
        void DeleteJournal(MedicJournal journal);
    }
}
