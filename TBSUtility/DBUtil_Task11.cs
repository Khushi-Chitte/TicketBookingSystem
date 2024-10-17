using System.Data.SqlClient;

namespace TBSUtility
{
    public class DBUtil_Task11
    {
        public static SqlConnection GetDBConn()
        {
            string connectionString = "Data Source=KHUSHI\\SQLEXPRESS;Initial Catalog=TBSAssignment;Integrated Security=True;TrustServerCertificate=True"; // Corrected connection string
            return new SqlConnection(connectionString);
        }
    }

}
