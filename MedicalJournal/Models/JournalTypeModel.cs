namespace MedicalJournal.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class JournalTypeModel
    {
        public Int64 ID { get; set; }
        [Display(Name = "Journal Type")]
        public string TypeName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FrontImage { get; set; }
    }
}