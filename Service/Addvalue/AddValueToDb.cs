using Infrastructure.DTO;
using Repository.Context;
using System.Collections.Generic;
using Models;
using Validation.AddValueToDB;
// ReSharper disable All

namespace Service.Addvalue
{
    public class AddValueToDb : IAddValue
    {
        private readonly IUnitOfWork _db;
        private readonly ICheckValue _check;
        public AddValueToDb(IUnitOfWork db , ICheckValue check)
        {
            _db = db;
            _check = check;
        }

        public string AddToValueTable(List<ValueDto> values)
        {
            if (_check.CheckValues(values) != "ok") return _check.CheckValues(values);
            foreach (var item in values)
            {
                _db.Value.Insert(new Value { TableId = item.TableId, FieldValue = item.FieldValue, Column = item.Column });
            }
            _db.Save();
            return "ok";
        }

        public List<Tables> AllTable()
        {
           return _db.Tables.GetAll();
        }

        public List<Types> TableData(int id)
        {

            return _db.Types.TableColumn(x => x.TableId == id);
        }
    }
}
