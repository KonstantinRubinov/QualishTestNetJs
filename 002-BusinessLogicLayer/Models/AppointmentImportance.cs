using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace QualishTestBLL
{
	[DataContract]
	public class AppointmentImportance
	{
		private int _importanceId;
		private string _importanceName;

		public AppointmentImportance(int _tmpImportanceId, string _tmpImportanceName)
		{
			importanceId = _tmpImportanceId;
			importanceName = _tmpImportanceName;
		}

		public AppointmentImportance()
		{

		}

		[DataMember]
		public int importanceId
		{
			get { return _importanceId; }
			set { _importanceId = value; }
		}

		[DataMember]
		public string importanceName
		{
			get { return _importanceName; }
			set { _importanceName = value; }
		}

		public override string ToString()
		{
			return
				importanceId + " " +
				importanceName;
		}

		public static AppointmentImportance ToObject(DataRow reader)
		{
			AppointmentImportance appointmentImportance = new AppointmentImportance();
			appointmentImportance.importanceId = int.Parse(reader[0].ToString());
			appointmentImportance.importanceName = reader[1].ToString();

			Debug.WriteLine("appointmentImportance: " + appointmentImportance.ToString());
			return appointmentImportance;
		}
	}
}
