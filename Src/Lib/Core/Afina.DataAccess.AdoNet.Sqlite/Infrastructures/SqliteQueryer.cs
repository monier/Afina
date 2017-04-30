using System;
using System.Data.Common;
using Afina.DataAccess.AdoNet.Instrumentations;
using System.Collections.Generic;
using System.Data;

namespace Afina.DataAccess.AdoNet.Sqlite.Infrastructures
{
    public class SqliteQueryer : Queryer
    {
        private readonly Dictionary<Type, IDbValueMapper> _valueMappers;
        public SqliteQueryer(IConnectionStringProvider connectionStringProvider, DbProviderFactory providerFactory) : base(connectionStringProvider, providerFactory)
        {
            _valueMappers = new Dictionary<Type, IDbValueMapper>();
            _valueMappers.Add(typeof(DateTime), new DateTimeValueMapper());
            _valueMappers.Add(typeof(int), new IntValueMapper());
        }
        public override DbParameter CreateParameter(DbCommand command, string name, object value, Action<DbParameter> actionOnParameter = null)
        {
            if (value != null)
            {
                IDbValueMapper mapper = null;
                if(_valueMappers.TryGetValue(value.GetType(),out mapper))
                {
                    value = mapper.MapToDb(value);
                }
            }
            return base.CreateParameter(command, name, value, actionOnParameter);
        }
        public override T ReadValue<T>(IDataReader reader, string name)
        {
            IDbValueMapper mapper = null;
            if (_valueMappers.TryGetValue(typeof(T),out mapper))
            {
                var value = base.ReadValue<object>(reader, name);
                return (T)mapper.MapFromDb(value);
            }
            return base.ReadValue<T>(reader, name);
        }
    }
}
