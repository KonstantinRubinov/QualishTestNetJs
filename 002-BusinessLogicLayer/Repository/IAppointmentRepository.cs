using System;
using System.Collections.Generic;

namespace QualishTestBLL
{
	public interface IAppointmentRepository
	{
		List<Appointment> GetAllAppointments();
		List<Appointment> GetAppointmentsByDate(DateTime currentDate);
		List<Appointment> GetAppointmentsByDates(DateTime startDate, DateTime endDate);

		List<Appointment> GetAppointmentsByStart(DateTime startDate);
		List<Appointment> GetAppointmentsByEnd(DateTime startDate);


		Appointment GetOneAppointment(int appointmentId);
		Appointment AddAppointment(Appointment appointment);
		Appointment UpdateAppointment(Appointment appointment);
		int DeleteAppointment(int appointmentId);
	}
}