using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QualishTestBLL
{
	[DataContract]
	public class AllData
	{
		private List<Appointment> _appointments;
		private List<AppointmentImportance> _appointmentImportances;
		private List<AppointmentType> _appointmentTypes;

		public AllData(List<Appointment> _tmpAppointments, List<AppointmentImportance> _tmpAppointmentImportances, List<AppointmentType> _tmpAppointmentTypes)
		{
			appointments = _tmpAppointments;
			appointmentImportances = _tmpAppointmentImportances;
			appointmentTypes = _tmpAppointmentTypes;
		}

		public AllData()
		{

		}

		[DataMember]
		public List<Appointment> appointments
		{
			get { return _appointments; }
			set { _appointments = value; }
		}

		[DataMember]
		public List<AppointmentImportance> appointmentImportances
		{
			get { return _appointmentImportances; }
			set { _appointmentImportances = value; }
		}

		[DataMember]
		public List<AppointmentType> appointmentTypes
		{
			get { return _appointmentTypes; }
			set { _appointmentTypes = value; }
		}
	}
}
