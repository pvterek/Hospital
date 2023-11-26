using Hospital.Entities.Interfaces;
using NHibernate;

namespace Hospital.Database.Interfaces;

public interface IDatabaseOperations
{
    bool Add<T>(T entity, ISession session) where T : IHasIntroduceString;
    bool Delete<T>(T entity, ISession session) where T : IHasIntroduceString;
    bool Update<T>(T entity, ISession session) where T : IHasIntroduceString;
    List<T> GetAll<T>(ISession session) where T : IHasIntroduceString;
}