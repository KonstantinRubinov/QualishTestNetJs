using System.Collections.Generic;

namespace QualishTestBLL
{
	public interface IAppointmentTypeRepository
	{
		List<AppointmentType> GetAllAppointmentTypes();
		AppointmentType GetOneAppointmentType(int appointmentTypeId);
		AppointmentType AddAppointmentType(AppointmentType appointmentType);
		AppointmentType UpdateAppointmentType(AppointmentType appointmentType);
		int DeleteAppointmentType(int appointmentTypeId);
	}
}
