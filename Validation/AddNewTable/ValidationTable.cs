using Infrastructure;
using Infrastructure.DTO;
using Repository.Context;
using System.Collections.Generic;

namespace Validation.AddNewTable
{
    public class ValidationTable : ICheckTableInput
    {
        private readonly IUnitOfWork _db;
        public ValidationTable( IUnitOfWork db)
        {
            _db = db;
        }

        public string CheckAllInput(List<TypesDto> types, string tableName)
        {
            if (CheckTableName(tableName) != Massage.IsOk) return CheckTableName(tableName);
            if (ColumnName(types) != Massage.IsOk) return ColumnName(types);
            return NumberOfColumn(types) != Massage.IsOk ? NumberOfColumn(types) : Massage.IsOk;
        }

        public string CheckTableName(string tableName)
        {
            return _db.Tables.FindValue(x => x.TableName == tableName) ?
            Massage.RepetitiveTableName : Massage.IsOk;
        }

        public string ColumnName(List<TypesDto> types)
        {
            var name = " ";
            foreach (var item in types)
            {
                
                if(item.FieldName == name)
                {
                    return Massage.RepetitiveColumnName;
                }
                name = item.FieldName;
            }
            return Massage.IsOk;
        }

        public string NumberOfColumn(List<TypesDto> types)
        {
            return types.Count == 0 ? Massage.AddColumn : Massage.IsOk;
        }
    }
}
