using QualishTestDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QualishTestBLL
{
	public class AppointmentTypeManager : DataBase, IAppointmentTypeRepository
	{
		public List<AppointmentType> GetAllAppointmentTypes()
		{
			DataTable dt = new DataTable();
			List<AppointmentType> arrAppointmentTypes = new List<AppointmentType>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentTypeStrings.GetAllAppointmentTypes());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrAppointmentTypes.Add(AppointmentType.ToObject(ms));
			}

			return arrAppointmentTypes;
		}

		public AppointmentType GetOneAppointmentType(int appointmentTypeId)
		{
			if (appointmentTypeId < 0)
				throw new ArgumentOutOfRangeException();
			DataTable dt = new DataTable();
			AppointmentType appointmentType = new AppointmentType();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentTypeStrings.GetOneAppointmentType(appointmentTypeId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				appointmentType = AppointmentType.ToObject(ms);
			}

			return appointmentType;
		}

		public AppointmentType AddAppointmentType(AppointmentType tmpAppointmentType)
		{
			DataTable dt = new DataTable();
			AppointmentType appointmentType = new AppointmentType();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentTypeStrings.AddAppointmentType(tmpAppointmentType));
			}

			foreach (DataRow ms in dt.Rows)
			{
				appointmentType = AppointmentType.ToObject(ms);
			}

			return appointmentType;
		}

		public AppointmentType UpdateAppointmentType(AppointmentType tmpAppointmentType)
		{
			DataTable dt = new DataTable();
			AppointmentType appointmentType = new AppointmentType();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentTypeStrings.UpdateAppointmentType(tmpAppointmentType));
			}

			foreach (DataRow ms in dt.Rows)
			{
				appointmentType = AppointmentType.ToObject(ms);
			}

			return appointmentType;
		}

		public int DeleteAppointmentType(int appointmentTypeId)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(AppointmentTypeStrings.DeleteAppointmentType(appointmentTypeId));
			}
			return i;
		}
	}
}