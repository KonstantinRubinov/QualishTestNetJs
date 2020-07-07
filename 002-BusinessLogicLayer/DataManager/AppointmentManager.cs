using QualishTestDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QualishTestBLL
{
	public class AppointmentManager : DataBase, IAppointmentRepository
	{
		public List<Appointment> GetAllAppointments()
		{
			DataTable dt = new DataTable();
			List<Appointment> arrAppointments = new List<Appointment>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentStrings.GetAllAppointments());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrAppointments.Add(Appointment.ToObject(ms));
			}

			return arrAppointments;
		}

		public List<Appointment> GetAppointmentsByDate(DateTime currentDate)
		{
			DataTable dt = new DataTable();
			List<Appointment> arrAppointments = new List<Appointment>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentStrings.GetAppointmentsByDate(currentDate));
			}
			foreach (DataRow ms in dt.Rows)
			{
				arrAppointments.Add(Appointment.ToObject(ms));
			}

			return arrAppointments;
		}

		public List<Appointment> GetAppointmentsByDates(DateTime startDate, DateTime endDate)
		{
			DataTable dt = new DataTable();
			List<Appointment> arrAppointments = new List<Appointment>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentStrings.GetAppointmentsByDates(startDate, endDate));
			}
			foreach (DataRow ms in dt.Rows)
			{
				arrAppointments.Add(Appointment.ToObject(ms));
			}

			return arrAppointments;
		}






		public List<Appointment> GetAppointmentsByStart(DateTime startDate)
		{
			DataTable dt = new DataTable();
			List<Appointment> arrAppointments = new List<Appointment>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentStrings.GetAppointmentsByStart(startDate));
			}
			foreach (DataRow ms in dt.Rows)
			{
				arrAppointments.Add(Appointment.ToObject(ms));
			}

			return arrAppointments;
		}

		public List<Appointment> GetAppointmentsByEnd(DateTime endDate)
		{
			DataTable dt = new DataTable();
			List<Appointment> arrAppointments = new List<Appointment>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentStrings.GetAppointmentsByEnd(endDate));
			}
			foreach (DataRow ms in dt.Rows)
			{
				arrAppointments.Add(Appointment.ToObject(ms));
			}

			return arrAppointments;
		}















		public Appointment GetOneAppointment(int appointmentId)
		{
			if (appointmentId < 0)
				throw new ArgumentOutOfRangeException();
			DataTable dt = new DataTable();
			Appointment appointment = new Appointment();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(AppointmentStrings.GetOneAppointment(appointmentId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				appointment = Appointment.ToObject(ms);
			}

			return appointment;
		}

		public Appointment AddAppointment(Appointment tmpAppointment)
		{
			bool avaliable;
			bool hours;
			bool days;

			avaliable = CheckIfAppointmentAvaliable(tmpAppointment.appointmentDate, tmpAppointment.startTime, tmpAppointment.endTime, tmpAppointment.appointmentId);
			if (avaliable)
			{
				//hours = CheckAppointmentTime(tmpAppointment);
				//if (hours)
				//{
					//days = CheckAppointmentDay(tmpAppointment);
					//if (days)
					//{
						DataTable dt = new DataTable();
						Appointment appointment = new Appointment();

						using (SqlCommand command = new SqlCommand())
						{
							dt = GetMultipleQuery(AppointmentStrings.AddAppointment(tmpAppointment));
						}

						foreach (DataRow ms in dt.Rows)
						{
							appointment = Appointment.ToObject(ms);
						}

						return appointment;
					}
				//	else
				//	{
				//		throw new DayNotAvaliableException("The Day Is Not Avaliable");
				//	}
				//}
			//	else
			//	{
			//		throw new DurationNotAvaliableException("The Duration Is Not Avaliable");
			//	}
			//}
			else
			{
				throw new DateNotAvaliableException("The Time Is Not Avaliable");
			}
		}

		public Appointment UpdateAppointment(Appointment tmpAppointment)
		{
			bool avaliable;
			bool hours;
			bool days;

			avaliable = CheckIfAppointmentAvaliable(tmpAppointment.appointmentDate, tmpAppointment.startTime, tmpAppointment.endTime, tmpAppointment.appointmentId);
			if (avaliable)
			{
				//hours = CheckAppointmentTime(tmpAppointment);
				//if (hours)
				//{
				//	days = CheckAppointmentDay(tmpAppointment);
				//	if (days)
				//	{
						DataTable dt = new DataTable();
						Appointment appointment = new Appointment();

						using (SqlCommand command = new SqlCommand())
						{
							dt = GetMultipleQuery(AppointmentStrings.UpdateAppointment(tmpAppointment));
						}

						foreach (DataRow ms in dt.Rows)
						{
							appointment = Appointment.ToObject(ms);
						}

						return appointment;
					}
			//		else
			//		{
			//			throw new DayNotAvaliableException("The Day Is Not Avaliable");
			//		}
			//	}
			//	else
			//	{
			//		throw new DurationNotAvaliableException("The Duration Is Not Avaliable");
			//	}
			//}
			else
			{
				throw new DateNotAvaliableException("The Time Is Not Avaliable");
			}
		}

		public int DeleteAppointment(int appointmentId)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(AppointmentStrings.DeleteAppointment(appointmentId));
			}
			return i;
		}


		//public bool CheckAppointmentDay(Appointment tmpAppointment)
		//{
		//	if ((tmpAppointment.importanceId != 2) && (tmpAppointment.appointmentDate.DayOfWeek == DayOfWeek.Friday || tmpAppointment.appointmentDate.DayOfWeek == DayOfWeek.Saturday))
		//	{
		//		return false;
		//	}
		//	else if((tmpAppointment.importanceId == 2) && (tmpAppointment.appointmentDate.DayOfWeek == DayOfWeek.Saturday))
		//	{
		//		return false;
		//	}
		//	return true;
		//}

		//public bool CheckAppointmentTime(Appointment tmpAppointment)
		//{
		//	if (tmpAppointment.importanceId == 1)
		//	{
		//		var hours = (tmpAppointment.endTime - tmpAppointment.startTime).TotalHours;
		//		if (hours > 2)
		//		{
		//			return false;
		//		}
		//		return true;
		//	}
		//	return true;
		//}

		private bool CheckIfAppointmentAvaliable(DateTime appointmentDate, DateTime fromTime, DateTime toTime, int appointmentId=-1)
		{
			List<Appointment> arrAppointments = GetAppointmentsByDate(appointmentDate);

			if (appointmentId != -1) arrAppointments = arrAppointments.Where(appointment => (appointment.appointmentId != appointmentId)).ToList();

			if (arrAppointments != null && arrAppointments.Count > 0)
			{
				if (DateTime.Compare((DateTime)toTime, arrAppointments[0].startTime) < 0)
				{
					return true;
				}
				if (DateTime.Compare((DateTime)fromTime, arrAppointments[arrAppointments.Count - 1].endTime) > 0)
				{
					return true;
				}

				for (int i = 0; i < arrAppointments.Count - 1; i++)
				{
					if (DateTime.Compare((DateTime)fromTime, arrAppointments[i].endTime) > 0 && DateTime.Compare((DateTime)toTime, arrAppointments[i + 1].startTime) < 0)
					{
						return true;
					}
				}
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}