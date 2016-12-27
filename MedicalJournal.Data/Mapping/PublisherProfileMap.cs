namespace MedicalJournal.Data.Mapping
{
    using Core.Data;
    using System.Data.Entity.ModelConfiguration;
    public class PublisherProfileMap : EntityTypeConfiguration<PublisherProfile>
    {
        public PublisherProfileMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.FirstName);
            Property(t => t.LastName);
            Property(t => t.Address);
            Property(t => t.AddedDate);
            Property(t => t.ModifiedDate);
            //table
            ToTable("PublisherProfiles");
            HasRequired(t => t.Publisher).WithRequiredDependent(u => u.PublisherProfile);
            //HasRequired(t => t.MedicJournal).WithRequiredDependent(u => u.PublisherProfile);
        }
    }
}
