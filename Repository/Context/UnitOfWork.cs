using Models;

// ReSharper disable All

namespace Repository.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private Repository<Types> _types;

        public IRepository<Types> Types
        {
            get
            {
                return _types ??
                    (_types = new Repository<Types>(_context));    
            }
        }

        Repository<Value> _value;
        public IRepository<Value> Value
        {
            get
            {
                return _value ??
                    (_value = new Repository<Value>(_context));
            }
        }

        Repository<CreateTime> _time;
        public IRepository<CreateTime> Times
        {
            get
            {
                return _time ??
                    (_time = new Repository<CreateTime>(_context));
            }
        }

        private Repository<Tables> _table;
        public IRepository<Tables> Tables
        {
            get
            {
                return _table ??
                    (_table = new Repository<Tables>(_context));
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
