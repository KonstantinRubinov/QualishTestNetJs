using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace QualishTestBLL
{
	[DataContract]
	public class Appointment
	{
		private int _appointmentId;
		private string _customerName;
		private DateTime _appointmentDate;
		private DateTime _startTime;
		private DateTime _endTime;
		private int _appointmentTypeId;
		private int _importanceId;

		public Appointment(int _tmpAppointmentId, string _tmpCustomerName, DateTime _tmpAppointmentDate, DateTime _tmpStartTime, DateTime _tmpEndTime, int _tmpAppointmentTypeId, int _tmpImportanceId)
		{
			appointmentId = _tmpAppointmentId;
			customerName = _tmpCustomerName;
			appointmentDate = _tmpAppointmentDate;
			startTime = _tmpStartTime;
			endTime = _tmpEndTime;
			appointmentTypeId = _tmpAppointmentTypeId;
			importanceId = _tmpImportanceId;
		}

		public Appointment()
		{

		}

		[DataMember]
		public int appointmentId
		{
			get { return _appointmentId; }
			set { _appointmentId = value; }
		}

		[DataMember]
		public string customerName
		{
			get { return _customerName; }
			set { _customerName = value; }
		}

		[DataMember]
		public DateTime appointmentDate
		{
			get { return _appointmentDate; }
			set { _appointmentDate = value; }
		}

		[DataMember]
		public DateTime startTime
		{
			get { return _startTime; }
			set { _startTime = value; }
		}

		[DataMember]
		public DateTime endTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}

		[DataMember]
		public int appointmentTypeId
		{
			get { return _appointmentTypeId; }
			set { _appointmentTypeId = value; }
		}

		[DataMember]
		public int importanceId
		{
			get { return _importanceId; }
			set { _importanceId = value; }
		}

		public override string ToString()
		{
			return
				appointmentId + " " +
				customerName + " " +
				appointmentDate + " " +
				startTime + " " +
				endTime + " " +
				appointmentTypeId + " " +
				importanceId;
		}

		public static Appointment ToObject(DataRow reader)
		{
			Appointment appointment = new Appointment();
			appointment.appointmentId = int.Parse(reader[0].ToString());
			appointment.customerName = reader[1].ToString();
			appointment.appointmentDate = DateTime.Parse(reader[2].ToString());
			appointment.startTime = DateTime.Parse(reader[3].ToString());
			appointment.endTime = DateTime.Parse(reader[4].ToString());
			appointment.appointmentTypeId = int.Parse(reader[5].ToString());
			appointment.importanceId = int.Parse(reader[6].ToString());

			Debug.WriteLine("appointment: " + appointment.ToString());
			return appointment;
		}
	}
}
