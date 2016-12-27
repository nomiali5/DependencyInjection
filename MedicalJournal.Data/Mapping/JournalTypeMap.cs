namespace MedicalJournal.Data.Mapping
{
    using Core.Data;
    using System.Data.Entity.ModelConfiguration;
    public class JournalTypeMap : EntityTypeConfiguration<JournalType>
    {
        public JournalTypeMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.TypeName);
            //Property(t => t.ReTypePassword).IsRequired().HasColumnType("password");
            Property(t => t.AddedDate);
            Property(t => t.ModifiedDate);
            Property(t => t.FrontImage);
            //table
            ToTable("JournalTypes");
        }
    }
}