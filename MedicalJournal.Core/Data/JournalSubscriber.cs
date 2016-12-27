namespace MedicalJournal.Core.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class JournalSubscriber : BaseEntity
    {
        [StringLength(200)]
        public string Email { get; set; }
        public long MedicJournalID { get; set; }
        public virtual ICollection<MedicJournal> MedicJournal { get; set; }
    }
}
