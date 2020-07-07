using System.Data.SqlClient;

namespace QualishTestBLL
{
	static public class AppointmentImportanceStrings
	{
		static private string queryAppointmentImportanceString = "SELECT * from AppointmentImportances;";
		static private string queryAppointmentImportanceByIdString = "SELECT * from AppointmentImportances WHERE importanceId = @importanceId;";
		static private string queryAppointmentImportancePost = "INSERT INTO AppointmentImportances (importanceId, importanceName) VALUES (@importanceId, @importanceName); SELECT * FROM AppointmentImportances WHERE importanceId = SCOPE_IDENTITY();";
		static private string queryAppointmentImportanceUpdate = "UPDATE AppointmentImportances SET importanceName = @importanceName WHERE importanceId = @importanceId; SELECT * from AppointmentImportances WHERE importanceId = @importanceId;";
		static private string queryAppointmentImportanceDelete = "DELETE FROM AppointmentImportances WHERE importanceId = @importanceId;";

		static public SqlCommand GetAllAppointmentImportances()
		{
			return CreateSqlCommand(queryAppointmentImportanceString);
		}

		static public SqlCommand GetOneAppointmentImportance(int importanceId)
		{
			return CreateSqlCommandId(importanceId, queryAppointmentImportanceByIdString);
		}

		static public SqlCommand AddAppointmentImportance(AppointmentImportance appointmentImportance)
		{
			return CreateSqlCommand(appointmentImportance, queryAppointmentImportancePost);
		}

		static public SqlCommand UpdateAppointmentImportance(AppointmentImportance appointmentImportance)
		{
			return CreateSqlCommand(appointmentImportance, queryAppointmentImportanceUpdate);
		}

		static public SqlCommand DeleteAppointmentImportance(int importanceId)
		{
			return CreateSqlCommandId(importanceId, queryAppointmentImportanceDelete);
		}


		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}

		static private SqlCommand CreateSqlCommand(AppointmentImportance appointmentImportance, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@importanceId", appointmentImportance.importanceId);
			command.Parameters.AddWithValue("@importanceName", appointmentImportance.importanceName);

			return command;
		}

		static private SqlCommand CreateSqlCommandId(int importanceId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@importanceId", importanceId);

			return command;
		}
	}
}
