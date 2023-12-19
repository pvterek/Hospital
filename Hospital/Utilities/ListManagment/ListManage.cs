﻿using Hospital.Database;
using Hospital.Database.Interfaces;
using Hospital.Entities.Interfaces;
using Hospital.Utilities.UserInterface;

namespace Hospital.Utilities.ListManagment
{
    public class ListManage : IListManage
    {
        private readonly IDatabaseOperations _databaseOperations;
        private readonly CreateSession _createSession;

        public ListManage(
            IDatabaseOperations databaseOperations,
            CreateSession createSession)
        {
            _databaseOperations = databaseOperations;
            _createSession = createSession;
        }

        public void Add<T>(T item, List<T> list) where T : IHasIntroduceString
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), UiMessages.DatabaseExceptions.ItemNull);

            using var session = _createSession.SessionFactory.OpenSession();
            if (!_databaseOperations.Add(item, session))
            {
                throw new Exception(string.Format(UiMessages.DatabaseExceptions.AddException, typeof(T)));
            }

            list.Add(item);
        }

        public void Remove<T>(T item, List<T> list) where T : IHasIntroduceString
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), UiMessages.DatabaseExceptions.ItemNull);

            using var session = _createSession.SessionFactory.OpenSession();
            if (!_databaseOperations.Delete(item, session))
            {
                throw new Exception(string.Format(UiMessages.DatabaseExceptions.RemoveException, typeof(T)));
            }

            list.Remove(item);
        }

        public void Update<T>(T item, List<T> list) where T : IIdentifier, IHasIntroduceString
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), UiMessages.DatabaseExceptions.ItemNull);

            using var session = _createSession.SessionFactory.OpenSession();
            var index = list.FindIndex(existingItem => existingItem.Id == item.Id);

            if (index == -1)
            {
                throw new Exception(string.Format(UiMessages.DatabaseExceptions.ItemNull, typeof(T), item.Id));
            }

            if (!_databaseOperations.Update(item, session))
            {
                throw new Exception(string.Format(UiMessages.DatabaseExceptions.UpdateException, typeof(T)));
            }

            list[index] = item;
        }
    }
}