
using Infrastructure;
using Infrastructure.DTO;
using Repository.Context;
using System;
using System.Collections.Generic;
using Models;
using Validation.AddNewTable;

namespace Service.AddNewTable
{
    public class AddTable : IAddTable
    {
        private readonly IUnitOfWork _db;
        private readonly ICheckTableInput _check;
        public AddTable(IUnitOfWork db , ICheckTableInput check)
        {
            _db = db;
            _check = check;
        }
        public string AddInformationToDatabase(string tableName,List<TypesDto> types)
        {
            if (_check.CheckAllInput(types, tableName) !=Massage.IsOk) return _check.CheckAllInput(types, tableName);
            AddToTables(tableName);
            AddToTime(GetId(tableName));
            AddToType(types, GetId(tableName));
            _db.Save();
            return Massage.IsOk;
        }



        public void AddToTables(string model)
        {

            _db.Tables.Insert(new Tables { TableName=model });
            _db.Save();

        }

        public void AddToTime(int id)
        {
            _db.Times.Insert(new CreateTime { TableId = id, Time = DateTime.Now });
        }


        public void AddToType(List<TypesDto> types, int id)
        {
            foreach (var item in types)
            {
                _db.Types.Insert(new Types { FieldName = item.FieldName, FieldType = item.FieldType, TableId = id });
            }
        }

        int GetId(string name)
        {
            return _db.Tables.GetIdOfTable(x => x.TableName == name, x => x.Id);
        }
    }
}
