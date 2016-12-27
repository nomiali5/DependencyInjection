namespace MedicalJournal.Core.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("tblMedicalJournal")]
    public class MedicJournal : BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Journal Title Required")]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public string Details { get; set; }
        [StringLength(100)]
        public string Language { get; set; }
        [StringLength(100)]
        public string ISSN { get; set; }
        [StringLength(100)]
        public string EISSN { get; set; }
        [Display(Name = "ISI Impact Factor")]
        public string ISIImpactFactor { get; set; }
        [StringLength(200)]
        public string Writer { get; set; }
        public string PdfPath { get; set; }
        [Display(Name = "Source")]
        [DataType(DataType.Url)]
        public string WebsiteURL { get; set; }
        [Display(Name = "Publish Date")]
        [DataType(DataType.DateTime)]
        public Nullable<DateTime> PublishDate { get; set; }
        public Int64 JournalTypeID { get; set; }
        public JournalType JournalType { get; set; }
        public string FrontImage { get; set; }
    }
}
