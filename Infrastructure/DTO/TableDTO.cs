namespace Infrastructure.DTO
{
    public class TableDto
    {
        public TableDto()
        {

        }
        public TableDto(int id,string name)
        {
            Id = id;
            TableName = name;
        }
        public int Id { get; set; }

        public string TableName { get; set; }
    }
}
