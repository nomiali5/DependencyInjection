namespace MedicalJournal.Service
{
    using Core.Data;
    using MedicalJournal.Data;
    using MedicalJournal.Models;
    using MedicalJournal.Repository;
    using System.Linq;
    public class PubService : IPubService
    {
        private IPubRepository<ApplicationUser> publisherRepository;
        public PubService(IPubRepository<ApplicationUser> userRepository)
        {
            this.publisherRepository = userRepository;
        }
        public IQueryable<ApplicationUser> GetPublishers()
        {
            return publisherRepository.Table;
        }
        public ApplicationUser GetPublisher(string id)
        {
            return publisherRepository.GetById(id);
        }
        public void InsertPublisher(ApplicationUser publisher)
        {
            publisherRepository.Insert(publisher);
        }
        public void UpdatePublisher(ApplicationUser publisher)
        {
            publisherRepository.Update(publisher);
        }

        public void DeletePublisher(ApplicationUser publisher)
        {
            publisherRepository.Delete(publisher);
        }
    }
}