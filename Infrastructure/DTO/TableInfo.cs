using System.Collections.Generic;

namespace Infrastructure.DTO
{
    public class TableInfo
    {
        public TableInfo()
        {

        }
        public TableInfo(string name)
        {
            TableName = name;
            Type = new List<Types>();
        }
        
        public string TableName { get; set; }
        public List<Types> Type { get; set; }

        public class Types
        {
            public Types()
            {
                ColumnName = null;
                Type = null;
            }
            public Types(string name, string type)
            {

                Type = type;
                ColumnName = name ;
            }
            public string ColumnName { get; set; }
            public string Type { get; set; }
        }
    }
}
