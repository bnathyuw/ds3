using System.Data;
using System.Data.SqlClient;

namespace DeliverySolutions.Web
{
    public class DatabaseConnectionChecker
    {
        private const string ConnectionString = "Server=(local)\\SQL2014;Database=DeliverySolutions;User Id=deliverysolutions;Password=deliverysolutions; ";

        public virtual int Check()
        {
            using (var sqlConnection =new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "dbo.HealthCheck";

                    return (int)sqlCommand.ExecuteScalar();
                }
            }
        }
    }
}