using System;
using System.Collections.Concurrent;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    public class EntityMapHolder : IEntityMapHolder
    {
        private readonly ConcurrentDictionary<Type, Action<object, QueryResult>> _mappers;

        public EntityMapHolder()
        {
            _mappers = new ConcurrentDictionary<Type, Action<object, QueryResult>>();
        }

        public void Register<T>(Action<T, QueryResult> mapper) where T : class
        {
            Type type = typeof(T);
            var value = new Action<object, QueryResult>((obj, res) => mapper((T)obj, res));
            _mappers.AddOrUpdate(type, value, (oldKey, oldValue) => value);
        }
        public Action<T,QueryResult> Get<T>() where T : class
        {
            Type type = typeof(T);
            Action<object, QueryResult> value = null;
            if (_mappers.TryGetValue(type,out value))
            {
                return value;
            }
            return null;
        }
        public void MapEntity<T>(T entity, QueryResult queryResult) where T : class
        {
            Action<T, QueryResult> mapper = Get<T>();
            if (mapper != null)
            {
                mapper(entity, queryResult);
            }
            else
            {
                throw new NotRegisteredMapperException($"No valid mapper found for the entity {typeof(T).Name}");
            }
        }
    }
}
