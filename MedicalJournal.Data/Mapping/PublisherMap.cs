namespace MedicalJournal.Data.Mapping
{
    using Core.Data;
    using System.Data.Entity.ModelConfiguration;
    public class PublisherMap : EntityTypeConfiguration<Publisher>
    {
        public PublisherMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.UserName);
            Property(t => t.Email);
            Property(t => t.Password);
            //Property(t => t.ReTypePassword).IsRequired().HasColumnType("password");
            Property(t => t.AddedDate);
            Property(t => t.ModifiedDate);
            //table
            ToTable("Publishers");
        }
    }
}
