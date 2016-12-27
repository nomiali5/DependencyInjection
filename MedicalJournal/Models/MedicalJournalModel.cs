namespace MedicalJournal.Models
{
    using System;
    using MedicalJournal.Core.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using System.Collections.Generic;
    public class MedicalJournalModel
    {
        public MedicalJournalModel()
        {
            JournalTypeList = new SelectList(new List<string>());
        }
        [Required(ErrorMessage = "Journal Title Required")]
        public Int64 ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Language { get; set; }
        [StringLength(100)]
        public string ISSN { get; set; }
        [StringLength(100)]
        public string EISSN { get; set; }
        [Display(Name = "ISI Impact Factor")]
        public string ISIImpactFactor { get; set; }
        public string Writer { get; set; }
        public string PdfPath { get; set; }
        [Display(Name = "Source")]
        [DataType(DataType.Url)]
        public string WebsiteURL { get; set; }
        [Display(Name = "Journal Type")]
        [DataType(DataType.DateTime)]
        public SelectList JournalTypeList { get; set; }
        public int JournalTypeID { get; set; }
        public string TypeName { get; set; }
        public JournalType JournalType { get; set; }
        public Nullable<DateTime> PublishDate { get; set; }
        public string FrontImage { get; set; }
    }
}