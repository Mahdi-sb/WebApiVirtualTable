using Infrastructure.DTO;
using System.Collections.Generic;
using Models;

namespace Service.Addvalue
{
    public interface IAddValue
    {
        /// <summary>
        /// Add values to Value Table 
        /// </summary>
        /// <param name="values"></param>
        string AddToValueTable(List<ValueDto> values);

        /// <summary>
        /// return information of table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Types> TableData(int id);
        /// <summary>
        /// return all table name 
        /// </summary>
        /// <returns></returns>
        List<Tables> AllTable();

    }
}
