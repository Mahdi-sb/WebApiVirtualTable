using Repository.Context;
using System.Collections.Generic;
using Models;

namespace Service.ShowInformation
{
    public class ShowInfo : IShowInfo
    {
        private readonly IUnitOfWork _db;
        public ShowInfo(IUnitOfWork db)
        {
            _db = db;
        }
        public List<string> AllType(int id)
        {
            return _db.Types.AllType(x => x.TableId == id, x => x.FieldName);
        }

        public List<Value> ValueOfTable(int id)
        {
           return _db.Value.TableColumn(x => x.TableId == id);
        }
    }
}
