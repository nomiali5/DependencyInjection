namespace MedicalJournal.Service
{
    using Core.Data;
    using MedicalJournal.Data;
    using System.Linq;
    public class PublisherService : IPublisherService
    {
        private IRepository<Publisher> publisherRepository;
        private IRepository<PublisherProfile> publisherProfileRepository;
        public PublisherService(IRepository<Publisher> userRepository, IRepository<PublisherProfile> userProfileRepository)
        {
            this.publisherRepository = userRepository;
            this.publisherProfileRepository = userProfileRepository;
        }

        public IQueryable<Publisher> GetPublishers()
        {
            return publisherRepository.Table;
        }

        public Publisher GetPublisher(long id)
        {
            return publisherRepository.GetById(id);
        }

        public void InsertPublisher(Publisher publisher)
        {
            publisherRepository.Insert(publisher);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            publisherRepository.Update(publisher);
        }

        public void DeletePublisher(Publisher publisher)
        {
            publisherProfileRepository.Delete(publisher.PublisherProfile);
            publisherRepository.Delete(publisher);
        }
    }
}
