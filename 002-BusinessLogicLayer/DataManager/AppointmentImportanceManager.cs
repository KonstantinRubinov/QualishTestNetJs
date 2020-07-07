using QualishTestDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QualishTestBLL
{
	public class AppointmentImportanceManager : DataBase, IAppointmentImportanceRepository
	{
		public List<AppointmentImportance> GetAllAppointmentImportances()
		{
			DataTable dt = new DataTable();
			List<AppointmentImportance> arrAppointmentImportances = new List<AppointmentImportance>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentImportanceStrings.GetAllAppointmentImportances());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrAppointmentImportances.Add(AppointmentImportance.ToObject(ms));
			}

			return arrAppointmentImportances;
		}

		public AppointmentImportance GetOneAppointmentImportance(int appointmentImportanceId)
		{
			if (appointmentImportanceId < 0)
				throw new ArgumentOutOfRangeException();
			DataTable dt = new DataTable();
			AppointmentImportance appointmentImportance = new AppointmentImportance();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentImportanceStrings.GetOneAppointmentImportance(appointmentImportanceId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				appointmentImportance = AppointmentImportance.ToObject(ms);
			}

			return appointmentImportance;
		}

		public AppointmentImportance AddAppointmentImportance(AppointmentImportance tmpAppointmentImportance)
		{
			DataTable dt = new DataTable();
			AppointmentImportance appointmentImportance = new AppointmentImportance();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentImportanceStrings.AddAppointmentImportance(tmpAppointmentImportance));
			}

			foreach (DataRow ms in dt.Rows)
			{
				appointmentImportance = AppointmentImportance.ToObject(ms);
			}

			return appointmentImportance;
		}

		public AppointmentImportance UpdateAppointmentImportance(AppointmentImportance tmpAppointmentImportance)
		{
			DataTable dt = new DataTable();
			AppointmentImportance appointmentImportance = new AppointmentImportance();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentImportanceStrings.UpdateAppointmentImportance(tmpAppointmentImportance));
			}

			foreach (DataRow ms in dt.Rows)
			{
				appointmentImportance = AppointmentImportance.ToObject(ms);
			}

			return appointmentImportance;
		}

		public int DeleteAppointmentImportance(int appointmentImportanceId)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(AppointmentImportanceStrings.DeleteAppointmentImportance(appointmentImportanceId));
			}
			return i;
		}
	}
}