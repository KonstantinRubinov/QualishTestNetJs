export class AppointmentModel {
	constructor(tmpAppointmentId = "", tmpCustomerName = "", tmpAppointmentDate = "", tmpStartTime = "", tmpEndTime = "", tmpAppointmentTypeId = "", tmpImportanceId = "") {
		this.appointmentId = tmpAppointmentId;
		this.customerName = tmpCustomerName;
		this.appointmentDate = tmpAppointmentDate;
		this.startTime = tmpStartTime;
		this.endTime = tmpEndTime;
		this.appointmentTypeId = tmpAppointmentTypeId;
		this.importanceId = tmpImportanceId;
    }
}