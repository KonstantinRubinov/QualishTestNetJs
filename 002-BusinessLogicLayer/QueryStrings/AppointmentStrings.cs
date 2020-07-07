using System;
using System.Data.SqlClient;

namespace QualishTestBLL
{
	static public class AppointmentStrings
	{
		static private string queryAppointmentByDateString = "SELECT * from Appointments WHERE appointmentDate = @currentDate ORDER BY startTime;";
		static private string queryAppointmentByDatesString = "SELECT * from Appointments WHERE appointmentDate BETWEEN @startDate AND @endDate ORDER BY appointmentDate, startTime;";
		static private string queryAppointmentByStartDateString = "SELECT * from Appointments WHERE appointmentDate >= @startDate ORDER BY appointmentDate, startTime;";
		static private string queryAppointmentByEndDateString = "SELECT * from Appointments WHERE appointmentDate <= @endDate ORDER BY appointmentDate, startTime;";
		static private string queryAppointmentString = "SELECT * from Appointments ORDER BY appointmentDate, startTime;";
		static private string queryAppointmentByIdString = "SELECT * from Appointments WHERE appointmentId = @appointmentId;";
		static private string queryAppointmentPost = "INSERT INTO Appointments (customerName, appointmentDate, startTime, endTime, appointmentTypeId, importanceId) VALUES (@customerName, @appointmentDate, @startTime, @endTime, @appointmentTypeId, @importanceId); SELECT * FROM Appointments WHERE appointmentId = SCOPE_IDENTITY();";
		static private string queryAppointmentUpdate = "UPDATE Appointments SET customerName = @customerName, appointmentDate = @appointmentDate, startTime = @startTime, endTime = @endTime, appointmentTypeId = @appointmentTypeId, importanceId = @importanceId WHERE appointmentId = @appointmentId; SELECT * from Appointments WHERE appointmentId = @appointmentId;";
		static private string queryAppointmentDelete = "DELETE FROM Appointments WHERE appointmentId = @appointmentId;";

		static public SqlCommand GetAllAppointments()
		{
			return CreateSqlCommand(queryAppointmentString);
		}

		static public SqlCommand GetAppointmentsByDate(DateTime currentDate)
		{
			return CreateSqlCommandByDate(currentDate, queryAppointmentByDateString);
		}

		static public SqlCommand GetAppointmentsByDates(DateTime startDate, DateTime endDate)
		{
			return CreateSqlCommandByDates(startDate, endDate, queryAppointmentByDatesString);
		}

		static public SqlCommand GetAppointmentsByStart(DateTime startDate)
		{
			return CreateSqlCommandByStart(startDate, queryAppointmentByStartDateString);
		}

		static public SqlCommand GetAppointmentsByEnd(DateTime endDate)
		{
			return CreateSqlCommandByEnd(endDate, queryAppointmentByEndDateString);
		}

		static public SqlCommand GetOneAppointment(int appointmentId)
		{
			return CreateSqlCommandId(appointmentId, queryAppointmentByIdString);
		}

		static public SqlCommand AddAppointment(Appointment appointment)
		{
			return CreateSqlCommand(appointment, queryAppointmentPost);
		}

		static public SqlCommand UpdateAppointment(Appointment appointment)
		{
			return CreateSqlCommand(appointment, queryAppointmentUpdate);
		}

		static public SqlCommand DeleteAppointment(int appointmentId)
		{
			return CreateSqlCommandId(appointmentId, queryAppointmentDelete);
		}


		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}

		static private SqlCommand CreateSqlCommand(Appointment appointment, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@appointmentId", appointment.appointmentId);
			command.Parameters.AddWithValue("@customerName", appointment.customerName);
			command.Parameters.AddWithValue("@appointmentDate", appointment.appointmentDate);
			command.Parameters.AddWithValue("@startTime", appointment.startTime);
			command.Parameters.AddWithValue("@endTime", appointment.endTime);
			command.Parameters.AddWithValue("@appointmentTypeId", appointment.appointmentTypeId);
			command.Parameters.AddWithValue("@importanceId", appointment.importanceId);

			return command;
		}

		static private SqlCommand CreateSqlCommandByDates(DateTime startDate, DateTime endDate, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@startDate", startDate);
			command.Parameters.AddWithValue("@endDate", endDate);

			return command;
		}

		static private SqlCommand CreateSqlCommandByStart(DateTime startDate, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@startDate", startDate);

			return command;
		}

		static private SqlCommand CreateSqlCommandByEnd(DateTime endDate, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@endDate", endDate);

			return command;
		}

		static private SqlCommand CreateSqlCommandByDate(DateTime currentDate, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@currentDate", currentDate);

			return command;
		}

		static private SqlCommand CreateSqlCommandId(int appointmentId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@appointmentId", appointmentId);

			return command;
		}
	}
}