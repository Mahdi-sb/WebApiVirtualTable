using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Enum;

namespace Models
{
    public class Types
    {
        public int Id { get; set; }
        [ForeignKey("Tables")]
        public int TableId { get; set; }
        public string FieldName { get; set; }
        public ColumnTypes FieldType { get; set; }

    }
}
