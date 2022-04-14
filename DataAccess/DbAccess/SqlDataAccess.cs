using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public IEnumerable<T> LoadData<T, U>(string storedProcedure,
                                                     U parameters,
                                                     string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return connection.Query<T>(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }

    public void SaveData<T>(string storedProcedure,
                                  T parameters,
                                  string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        connection.Execute(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }
}
