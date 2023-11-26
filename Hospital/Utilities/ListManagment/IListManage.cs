using Hospital.Entities.Interfaces;

namespace Hospital.Utilities.ListManagment
{
    public interface IListManage
    {
        void Add<T>(T item, List<T> list) where T : IHasIntroduceString;
        void Remove<T>(T item, List<T> list) where T : IHasIntroduceString;
        void Update<T>(T item, List<T> list) where T : IIdentifier, IHasIntroduceString;
    }
}
