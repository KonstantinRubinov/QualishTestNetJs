using System.Collections.Generic;

namespace QualishTestBLL
{
	public interface IAppointmentImportanceRepository
	{
		List<AppointmentImportance> GetAllAppointmentImportances();
		AppointmentImportance GetOneAppointmentImportance(int appointmentImportanceId);
		AppointmentImportance AddAppointmentImportance(AppointmentImportance appointmentImportance);
		AppointmentImportance UpdateAppointmentImportance(AppointmentImportance appointmentImportance);
		int DeleteAppointmentImportance(int appointmentImportanceId);
	}
}