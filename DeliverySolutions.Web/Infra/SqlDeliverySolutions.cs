using System.Data;
using System.Data.SqlClient;
using DeliverySolutions.Web.Domain;

namespace DeliverySolutions.Web.Infra
{
    public class SqlDeliverToHomeSolutions : DeliverToHomeSolutions
    {
        private const string ConnectionString = "Server=(local)\\SQL2014;Database=DeliverySolutions;User Id=deliverysolutions;Password=deliverysolutions; ";

        public virtual void WriteTo(DeliverToHomeProposal deliverToHomeProposal)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "dbo.DeliverToHomeSolutions";

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            deliverToHomeProposal.AddSolution((string) reader["Name"]);
                        }
                    }
                }
            }
        }
    }
}