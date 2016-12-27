namespace MedicalJournal.Data.Mapping
{
    using Core.Data;
    using System.Data.Entity.ModelConfiguration;
    public class MedicJournalMap : EntityTypeConfiguration<MedicJournal>
    {
        public MedicJournalMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.Title);
            Property(t => t.Description);
            Property(t => t.Details);
            Property(t => t.Language);
            Property(t => t.ISSN);
            Property(t => t.EISSN);
            Property(t => t.ISIImpactFactor);
            Property(t => t.Writer);
            Property(t => t.PdfPath);
            Property(t => t.WebsiteURL);
            Property(t => t.PublishDate);
            Property(t => t.ISIImpactFactor);
            Property(t => t.AddedDate);
            Property(t => t.ModifiedDate);
            Property(t => t.FrontImage);
            //table
            ToTable("MedicJournal");
        }
    }
}
