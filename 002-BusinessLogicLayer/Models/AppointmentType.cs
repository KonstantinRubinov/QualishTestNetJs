using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace QualishTestBLL
{
	[DataContract]
	public class AppointmentType
	{
		private int _appointmentTypeId;
		private string _appointmentTypeName;

		public AppointmentType(int _tmpAppointmentTypeId, string _tmpAppointmentTypeName)
		{
			appointmentTypeId = _tmpAppointmentTypeId;
			appointmentTypeName = _tmpAppointmentTypeName;
		}

		public AppointmentType()
		{

		}

		[DataMember]
		public int appointmentTypeId
		{
			get { return _appointmentTypeId; }
			set { _appointmentTypeId = value; }
		}

		[DataMember]
		public string appointmentTypeName
		{
			get { return _appointmentTypeName; }
			set { _appointmentTypeName = value; }
		}

		public override string ToString()
		{
			return
				appointmentTypeId + " " +
				appointmentTypeName;
		}

		public static AppointmentType ToObject(DataRow reader)
		{
			AppointmentType appointmentType = new AppointmentType();
			appointmentType.appointmentTypeId = int.Parse(reader[0].ToString());
			appointmentType.appointmentTypeName = reader[1].ToString();
			
			Debug.WriteLine("appointmentType: " + appointmentType.ToString());
			return appointmentType;
		}
	}
}
