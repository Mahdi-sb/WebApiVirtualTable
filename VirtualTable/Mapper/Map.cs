using Infrastructure.DTO;
using Infrastructure.Enum;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using VirtualTable.ViewModel;

namespace VirtualTable.Mapper
{
   public static class Map 
    {
        public static List<TableDto> TableList(List<Tables> tables)
        {
            return tables.Select(item => new TableDto(item.Id, item.TableName)).ToList();
        }

        public static List<TypesDto> TypeList(List<Types> types)
        {
            return types.Select(item => new TypesDto(item.TableId, item.FieldName, item.FieldType, null)).ToList();
        }

        public static List<ValueDto> ValueList(List<Value> values)
        {
            return values.Select(item => new ValueDto(item.Id, item.FieldValue, item.Column)).ToList();
        }

        public static List<Types> TableData(string values)
        {

            return JsonConvert.DeserializeObject<List<Types>>(values);

        }

        public static List<TypesDto> TypeList(List<ValueDto> values)
        {
            return values.Select(item => new TypesDto(item.TableId, item.Column, item.Type, item.FieldValue)).ToList();
        }
        public static List<TypesDto> TypeList(TableInfo table)
        {
            return table.Type.Select(item => new TypesDto(item.ColumnName, FindType(item.Type))).ToList();
        }


        public static List<string> Types(List<ValueDto> values)
        {
            return values.Select(x => x.Column).Distinct().ToList();
        }

        public static TableInfo Table(TableView table)
        {
            var list = new TableInfo(table.TableName);
            foreach (var item in table.TypeList)
            {
                list.Type.Add(new TableInfo.Types( item.ColumnName,item.Type.ToString() ) );
            }
            return list;

        }
        private static ColumnTypes FindType(string type)
        {
            return type.ToLower() switch
            {
                "bool" => ColumnTypes.BOOL,
                "string" => ColumnTypes.STRING,
                _ => ColumnTypes.INT
            };
        }
    }
}
