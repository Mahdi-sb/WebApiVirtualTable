using Infrastructure.DTO;
using System.Collections.Generic;

namespace Validation.AddValueToDB
{
    public interface ICheckValue
    {
        /// <summary>
        /// check field value to not have digit on it
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>

        string CheckString(List<ValueDto> values);
        /// <summary>
        /// check field value to Bool type
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        string CheckBool(List<ValueDto> values);
        /// <summary>
        /// check field value to int type
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        string CheckInt(List<ValueDto> values);
        /// <summary>
        /// <returns></returns>
        /// check values is Correct
        /// </summary>
        /// <param name="values"></param>
        string CheckValues(List<ValueDto> values);
    }
}
