using Infrastructure.Enum;

namespace Infrastructure.DTO
{
    public class TypesDto
    {
        public TypesDto()
        {

        }
        public TypesDto(string name, ColumnTypes type)
        {
            FieldName = name;
            FieldType = type;
        }
        public TypesDto(int id,string name, ColumnTypes type , string value )
        {
            TableId = id;
            FieldName = name;
            FieldType = type;
            Value = value;
        }
        public string Value { get; set; }
        public int TableId { get; set; }
        public string FieldName { get; set; }
        public ColumnTypes FieldType { get; set; }
    }
}
