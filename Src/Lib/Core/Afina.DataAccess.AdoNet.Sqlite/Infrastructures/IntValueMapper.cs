using System;
using Afina.DataAccess.AdoNet.Instrumentations;

namespace Afina.DataAccess.AdoNet.Sqlite.Infrastructures
{
    public class IntValueMapper : IDbValueMapper
    {
        public object MapFromDb(object value)
        {
            return Convert.ToInt32(value);
        }

        public object MapToDb(object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
