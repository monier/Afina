using System;
using System.Data.Common;

namespace Afina.DataAccess.AdoNet.Instrumentations
{
    /// <summary>
    /// Parameter of a query to execute
    /// </summary>
    public class QueryParameter
    {
        /// <summary>
        /// Name of the parameter
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Value of the parameter
        /// </summary>
        public object Value { get; private set; }
        /// <summary>
        /// Methods to execute on the created <see cref="DbParameter"/>
        /// </summary>
        public Action<DbParameter> ActionOnParameter { get; private set; }
        public QueryParameter(string name, object value, Action<DbParameter> actionOnParameter = null)
        {
            Name = name;
            Value = value;
            ActionOnParameter = actionOnParameter;
        }
    }
}
