namespace QualishTestDAL
{
	static public class ConnectionStrings
	{
		static private string connectionString = "Data Source =.; Initial Catalog = QualishTest; Integrated Security = True";

		static public string GetSqlConnection()
		{
			return connectionString;
		}
	}
}
