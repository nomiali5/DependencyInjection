namespace MedicalJournal.Repository
{
    using MedicalJournal.Core;
    using System.Linq;
    using MedicalJournal.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    public interface IPubRepository<T> where T : IdentityUser
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
