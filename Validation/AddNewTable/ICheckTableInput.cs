using Infrastructure.DTO;
using System.Collections.Generic;

namespace Validation.AddNewTable
{
   public interface ICheckTableInput 
    {
        public string ColumnName(List<TypesDto> types);
        public string NumberOfColumn(List<TypesDto> types);
        public string CheckTableName(string tableName);
        public string CheckAllInput(List<TypesDto> types, string tableName);




    }
}
