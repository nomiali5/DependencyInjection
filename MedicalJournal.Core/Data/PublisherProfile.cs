namespace MedicalJournal.Core.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("tblPublisherProfile")]
    public class PublisherProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
