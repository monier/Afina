using Afina.DataAccess.AdoNet.Instrumentations;
using System;
using System.Globalization;

namespace Afina.DataAccess.AdoNet.Sqlite.Infrastructures
{
    public class DateTimeValueMapper : IDbValueMapper
    {
        public const string DateFormat = "yyyy-MM-DDTHH:mm:ss";
        public object MapFromDb(object value)
        {
            return DateTime.ParseExact(value.ToString(), DateFormat, CultureInfo.InvariantCulture);
        }

        public object MapToDb(object value)
        {
            return ((DateTime)value).ToString(DateFormat);
        }
    }
}
