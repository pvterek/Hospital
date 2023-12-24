using Hospital.Entities.Interfaces;

namespace Hospital.Utilities.ListManagment
{
    public interface IListManage
    {
        void Add<T>(T item, List<T> list) where T : IHasIntroduceString;
        void Delete<T>(T item, List<T> list) where T : IHasIntroduceString;
        void Update<T>(T item, List<T> list) where T : IIdentifier, IHasIntroduceString;
        void SoftDelete<T>(T item, List<T> list) where T : IIsDeleted, IIdentifier, IHasIntroduceString;
    }
}