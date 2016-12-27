namespace MedicalJournal.Data.Mapping
{
    using Core.Data;
    using System.Data.Entity.ModelConfiguration;
    public class JournalSubsubscriberMap : EntityTypeConfiguration<JournalSubscriber>
    {
        public JournalSubsubscriberMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.Email);
            Property(t => t.MedicJournalID);
            //Property(t => t.ReTypePassword).IsRequired().HasColumnType("password");
            Property(t => t.AddedDate);
            Property(t => t.ModifiedDate);
            //table
            ToTable("JournalSubsubscribers");
        }
    }
}