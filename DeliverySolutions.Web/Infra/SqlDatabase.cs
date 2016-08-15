using System.Data;
using System.Data.SqlClient;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Infra
{
    public class SqlDatabase : Database
    {
        private const string ConnectionString = "Server=(local)\\SQL2014;Database=DeliverySolutions;User Id=deliverysolutions;Password=deliverysolutions; ";

        public virtual void WriteStatusTo(DatabaseStatus databaseStatus)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "dbo.HealthCheck";

                    databaseStatus.SetDatabaseStatus((int)sqlCommand.ExecuteScalar() == 1);
                }
            }
        }
    }
}