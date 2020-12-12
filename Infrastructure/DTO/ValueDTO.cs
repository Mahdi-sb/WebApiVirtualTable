using Infrastructure.Enum;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTO
{
    public class ValueDto
    {
        public ValueDto()
        {

        }
        public ValueDto(int id,string name, string column)
        {
            TableId = id;
            Column = column;
            FieldValue = name;

        }
        [Required]
        public int TableId { get; set; }
        [Required]
        public string Column { get; set; }
        [Required(ErrorMessage = " وارد شود")]
        public string FieldValue { get; set; }
        public ColumnTypes Type { get; set; }


    }
}
