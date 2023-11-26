<<<<<<< HEAD
﻿using Hospital.Entities.Interfaces;
using NHibernate;

namespace Hospital.Database.Interfaces;

public interface IDatabaseOperations
{
    bool Add<T>(T entity, ISession session) where T : IHasIntroduceString;
    bool Delete<T>(T entity, ISession session) where T : IHasIntroduceString;
    bool Update<T>(T entity, ISession session) where T : IHasIntroduceString;
    List<T> GetAll<T>(ISession session) where T : IHasIntroduceString;
=======
﻿namespace Hospital.Database.Interfaces;

public interface IDatabaseOperations
{
    
>>>>>>> 2df675cc034cc9dc5ea30693e21d1ae24a13ee95
}