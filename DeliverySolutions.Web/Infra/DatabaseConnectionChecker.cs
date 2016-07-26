using System.Data;
using System.Data.SqlClient;
using DeliverySolutions.Web.Api;

namespace DeliverySolutions.Web
{
    public class DatabaseConnectionChecker
    {
        private const string ConnectionString = "Server=(local)\\SQL2014;Database=DeliverySolutions;User Id=deliverysolutions;Password=deliverysolutions; ";

        public virtual void WriteDatabaseStatusTo(BuildHealth healthBuilder)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "dbo.HealthCheck";

                    var databaseStatus = (int)sqlCommand.ExecuteScalar();
                    healthBuilder.AddCheck(new Check("Can connect to database", $"{databaseStatus}"));
                }
            }
        }
    }
}