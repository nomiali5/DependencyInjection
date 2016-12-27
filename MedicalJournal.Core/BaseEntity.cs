namespace MedicalJournal.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public abstract class BaseEntity
    {
        public Int64 ID { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}