using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Value
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Tables")]
        public int TableId { get; set; }
        [Required]
        public string Column { get; set; }
        [Required]
        public string FieldValue { get; set; }
    }
}
