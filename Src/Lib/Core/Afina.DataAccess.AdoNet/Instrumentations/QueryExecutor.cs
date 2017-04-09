namespace Afina.DataAccess.AdoNet.Instrumentations
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IQueryer _queryer;
        private readonly IQuerySelector _querySelector;

        public QueryExecutor(IQueryer queryer, IQuerySelector querySelector)
        {
            _queryer = queryer;
            _querySelector = querySelector;
        }

        public QueryResult Execute(string queryName, params QueryParameter[] parameters)
        {
            var connection = _queryer.OpenNewConnection();
            var reader = _queryer.ExecuteReader(connection, (command) =>
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = _querySelector.GetQuery(queryName);
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(_queryer.CreateParameter(command, parameter.Name, parameter.Value, parameter.ActionOnParameter));
                    }
                }
            });
            return new QueryResult(_queryer, reader, connection);
        }

        public int ExecuteNonQuery(string queryName, params QueryParameter[] parameters)
        {
            using (var connection = _queryer.OpenNewConnection())
            {
                return _queryer.ExecuteNonQuery(connection, (command) =>
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = _querySelector.GetQuery(queryName);
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(_queryer.CreateParameter(command, parameter.Name, parameter.Value, parameter.ActionOnParameter));
                        }
                    }
                });
            }
        }
    }
}
