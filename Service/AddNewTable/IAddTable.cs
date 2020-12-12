using Infrastructure.DTO;
using System.Collections.Generic;
// ReSharper disable All

namespace Service.AddNewTable
{
    public interface IAddTable
    {
        /// <summary>
        /// Add Value to Tables Table in Database
        /// </summary>
        /// <param name="model"></param>
        void AddToTables(string model);

        /// <summary>
        /// Add value to Type Table in Database
        /// </summary>
        /// <param name="types"></param>
        /// <param name="id"></param>
        void AddToType(List<TypesDto> types, int id);

        /// <summary>
        /// Add value to CreateTime Table in Database
        /// </summary>
        /// <param name="id"></param>
        void AddToTime(int id);

        string AddInformationToDatabase(string tableName,List<TypesDto> types);
    }
}
