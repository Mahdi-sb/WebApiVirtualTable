using Models;

namespace Repository.Context
{
    public interface IUnitOfWork
    {
        IRepository<Types> Types { get; }
        IRepository<CreateTime> Times { get; }
        IRepository<Value> Value { get; }
        IRepository<Tables> Tables { get; }
        void Save();







    }
}
