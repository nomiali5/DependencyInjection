namespace MedicalJournal.Core.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class JournalType : BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Journal type is required")]
        public string TypeName { get; set; }
        public string FrontImage { get; set; }
        public virtual ICollection<MedicJournal> MedicJournal { get; set; }
    }
}
