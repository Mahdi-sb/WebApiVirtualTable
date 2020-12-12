using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Validation.AddValueToDB
{
    public class CheckValue : ICheckValue
    {
        
        public string CheckBool(List<ValueDto> values)
        {
            return values.Any(item => item.Type == ColumnTypes.BOOL && (item.FieldValue.ToLower() != "true" && item.FieldValue.ToLower() != "false")) ? Massage.IsBool : Massage.IsOk;
        }

        public string CheckInt(List<ValueDto> values)
        {
            return values.Any(item => item.Type == ColumnTypes.INT && item.FieldValue.Any(char.IsLetter)) ? Massage.IsInt : Massage.IsOk;
        }

        public string CheckString(List<ValueDto> values)
        {
            return values.Any(item => item.Type == ColumnTypes.STRING && item.FieldValue.All(char.IsDigit)) ? Massage.IsString : Massage.IsOk;
        }

        public string CheckValues(List<ValueDto> values)
        {
            if (CheckString(values) != "ok") return CheckString(values);
            if (CheckInt(values) != "ok") return CheckInt(values);
            return CheckBool(values) != "ok" ? CheckBool(values) : Massage.IsOk;
        }
    }
}
