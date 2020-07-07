using System.Data.SqlClient;

namespace QualishTestBLL
{
	static public class AppointmentTypeStrings
	{
		static private string queryAppointmentTypeString = "SELECT * from AppointmentTypes;";
		static private string queryAppointmentTypeByIdString = "SELECT * from AppointmentTypes WHERE appointmentTypeId = @appointmentTypeId;";
		static private string queryAppointmentTypePost = "INSERT INTO AppointmentTypes (appointmentTypeName) VALUES (@appointmentTypeName); SELECT * FROM AppointmentTypes WHERE appointmentTypeId = SCOPE_IDENTITY();";
		static private string queryAppointmentTypeUpdate = "UPDATE AppointmentTypes SET appointmentTypeName = @appointmentTypeName WHERE appointmentTypeId = @appointmentTypeId; SELECT * from AppointmentTypes WHERE appointmentTypeId = @appointmentTypeId;";
		static private string queryAppointmentTypeDelete = "DELETE FROM AppointmentTypes WHERE appointmentTypeId = @appointmentTypeId;";

		static public SqlCommand GetAllAppointmentTypes()
		{
			return CreateSqlCommand(queryAppointmentTypeString);
		}

		static public SqlCommand GetOneAppointmentType(int appointmentTypeId)
		{
			return CreateSqlCommandId(appointmentTypeId, queryAppointmentTypeByIdString);
		}

		static public SqlCommand AddAppointmentType(AppointmentType appointmentType)
		{
			return CreateSqlCommand(appointmentType, queryAppointmentTypePost);
		}

		static public SqlCommand UpdateAppointmentType(AppointmentType appointmentType)
		{
			return CreateSqlCommand(appointmentType, queryAppointmentTypeUpdate);
		}

		static public SqlCommand DeleteAppointmentType(int appointmentTypeId)
		{
			return CreateSqlCommandId(appointmentTypeId, queryAppointmentTypeDelete);
		}


		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}

		static private SqlCommand CreateSqlCommand(AppointmentType appointmentType, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@appointmentTypeId", appointmentType.appointmentTypeId);
			command.Parameters.AddWithValue("@appointmentTypeName", appointmentType.appointmentTypeName);

			return command;
		}

		static private SqlCommand CreateSqlCommandId(int appointmentTypeId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@appointmentTypeId", appointmentTypeId);

			return command;
		}
	}
}