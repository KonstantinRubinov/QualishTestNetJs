import { getAppointments, getAppointmentById, getAppointmentsByDates, addAppointment, updateAppointment, deleteAppointment } from './networking/appointments_networking.js';

import { AppointmentModel } from './model/appointment_model.js';
import { AppointmentTypeModel } from './model/appointment_type_model.js';
import { AppointmentImportanceModel } from './model/appointment_importance_model.js';

var appointmentImportances;
var appointmentTypes;
var appointments;

let weekday = new Array(7);
weekday[0] = "Sunday";
weekday[1] = "Monday";
weekday[2] = "Tuesday";
weekday[3] = "Wednesday";
weekday[4] = "Thursday";
weekday[5] = "Friday";
weekday[6] = "Saturday";

function diff_minutes(start, end) {
	start = start.split(":");
	end = end.split(":");
	var startDate = new Date(0, 0, 0, start[0], start[1], 0);
	var endDate = new Date(0, 0, 0, end[0], end[1], 0);
	var diff = endDate.getTime() - startDate.getTime();
	var minutes = Math.floor(diff / 1000 / 60);
	return minutes;
}

function isRightMinutes(start, end) {
	start = start.split(":");
	end = end.split(":");
	var startDate = new Date(0, 0, 0, start[0], start[1], 0);
	var endDate = new Date(0, 0, 0, end[0], end[1], 0);

	if (endDate <= startDate) {
		return false;
	} else {
		return true;
    }
}


export function setAppointmentsTable(tmpAppointments, tmpAppointmentTypes, tmpAppointmentImportances) {

	appointmentImportances = [];
	appointmentTypes = [];
	appointments = [];

	if (Array.isArray(tmpAppointments)) {
		tmpAppointments.forEach((appointmentModel) => appointments.push(new AppointmentModel(appointmentModel.appointmentId, appointmentModel.customerName, appointmentModel.appointmentDate, appointmentModel.startTime, appointmentModel.endTime, appointmentModel.appointmentTypeId, appointmentModel.importanceId)));
	} else {
		appointments.push(new AppointmentModel(tmpAppointments.appointmentId, tmpAppointments.customerName, tmpAppointments.appointmentDate, tmpAppointments.startTime, tmpAppointments.endTime, tmpAppointments.appointmentTypeId, tmpAppointments.importanceId));
	}

	if (Array.isArray(tmpAppointmentTypes)) {
		tmpAppointmentTypes.forEach((appointmentTypeModel) => appointmentTypes.push(new AppointmentTypeModel(appointmentTypeModel.appointmentTypeId, appointmentTypeModel.appointmentTypeName)));
	} else {
		appointmentTypes.push(new AppointmentTypeModel(tmpAppointmentTypes.appointmentTypeId, tmpAppointmentTypes.appointmentTypeName));
	}

	if (Array.isArray(tmpAppointmentImportances)) {
		tmpAppointmentImportances.forEach((appointmentImportanceModel) => appointmentImportances.push(new AppointmentImportanceModel(appointmentImportanceModel.importanceId, appointmentImportanceModel.importanceName)));
	} else {
		appointmentImportances.push(new AppointmentImportanceModel(tmpAppointmentImportances.importanceId, tmpAppointmentImportances.importanceName));
	}

	if (document.getElementById('AppointmentsTable') != null) {
		document.getElementById("appointments").replaceChild(AppointmentsList(), document.getElementById('AppointmentsTable'));
	} else {
		document.getElementById("appointments").appendChild(CreateStartEndInputs("startDate"));
		document.getElementById("appointments").appendChild(CreateStartEndInputs("endDate"));
		document.getElementById("appointments").appendChild(CreateSearchButton());
		document.getElementById("appointments").appendChild(AppointmentsList());
	}

	document.getElementById("AppointmentsTable").style.textAlign = "center";
}

function CheckAppointmentDay(tmpAppointment)
{
	let date = new Date(tmpAppointment.appointmentDate);
	//date = new Date(date.getFullYear, date.getMonth, date.getDate);
	let appDay = weekday[date.getDay()];

	if ((tmpAppointment.importanceId != 3) && (appDay == "Friday" || appDay == "Saturday")) {
		return false;
	}
	else if ((tmpAppointment.importanceId == 3) && (appDay == "Saturday")) {
		return false;
	}
	return true;
}

function CheckAppointmentTime(tmpAppointment)
{
	if (tmpAppointment.importanceId == 1) {
		let munutes = diff_minutes(tmpAppointment.startTime, tmpAppointment.endTime);
		if (munutes > 120) {
			return false;
		}
		return true;
	}
	return true;
}

//function CheckIfAppointmentAvaliable(appointmentDate, fromTime, toTime) {
//	let appdByDate = [];
//	getAppointmentsByDate(appointmentDate).then(data => {
//		let arrAppointments = data;
//		arrAppointments.forEach((appointmentModel) => appdByDate.push(new AppointmentModel(appointmentModel.appointmentId, appointmentModel.customerName, appointmentModel.appointmentDate, appointmentModel.startTime, appointmentModel.endTime, appointmentModel.appointmentTypeId, appointmentModel.importanceId)));
//	})

//	if (appdByDate != null && appdByDate.Count > 0) {
//		if (toTime < appdByDate[0].startTime) {
//			return true;
//		}
//		if (fromTime > appdByDate[0].endTime) {
//			return true;
//		}

//		for (let i = 0; i < appdByDate.Count - 1; i++)
//		{
//			if (fromTime > appdByDate[i].endTime && toTime < appdByDate[i + 1].startTime) {
//				return true;
//			}
//		}
//		return true;
//	}
//	else {
//		return true;
//	}
//}

function EditAppointmentTable(rowCounter, event) {
	let appointmentId = document.getElementById("AppointmentBtn" + event + rowCounter).value;
	let customerName = document.getElementById("customerName" + rowCounter).value;
	let appointmentDate = document.getElementById("appointmentDate" + rowCounter).value;
	let startTime = document.getElementById("startTime" + rowCounter).value;
	let endTime = document.getElementById("endTime" + rowCounter).value;
	let appointmentTypeId;
	let importanceId;

	try {
		let appointmentTypeName = document.getElementById("appointmentTypeName" + rowCounter);
		appointmentTypeId = appointmentTypeName.options[appointmentTypeName.selectedIndex].value;
	} catch (error) {
		appointmentTypeId = -1;
	}

	try {
		let appointmentImportances = document.getElementById("appointmentImportancesName" + rowCounter);
		importanceId = appointmentImportances.options[appointmentImportances.selectedIndex].value;
	} catch (error) {
		importanceId = -1;
	}

	let haveNoInput = "Have no inputs\n";


	if (event != "Add") {
		if (appointmentId == null || appointmentId == "" || appointmentId == "undefined") {
			haveNoInput = haveNoInput + "appointmentId\n";
		}
	}

	if (event != "Delete") {
		if (customerName == null || customerName == "" || customerName == "undefined") {
			haveNoInput = haveNoInput + "customerName\n";
		}

		if (appointmentDate == null || appointmentDate == "" || appointmentDate == "undefined") {
			haveNoInput = haveNoInput + "appointmentDate\n";
		}

		if (startTime == null || startTime == "" || startTime == "undefined") {
			haveNoInput = haveNoInput + "startTime\n";
		}

		if (endTime == null || endTime == "" || endTime == "undefined") {
			haveNoInput = haveNoInput + "endTime\n";
		}

		if (appointmentTypeId == null || appointmentTypeId == "" || appointmentTypeId == "undefined") {
			haveNoInput = haveNoInput + "appointmentTypeId\n";
		}

		if (importanceId == null || importanceId == "" || importanceId == "undefined") {
			haveNoInput = haveNoInput + "importanceId\n";
		}
	}

	if (haveNoInput != "Have no inputs\n") {
		alert(haveNoInput);
		return;
	}

	if (!isRightMinutes(startTime, endTime)) {
		alert("Check time inputs\n Your end time is before start time");
		return;
	}

	let myAppointment = new AppointmentModel("", customerName, appointmentDate, startTime, endTime, appointmentTypeId, importanceId)

	//let avaliable;
	let hours;
	let days;

	//avaliable = CheckIfAppointmentAvaliable(myAppointment.appointmentDate, myAppointment.startTime, myAppointment.endTime);

	try {
		//if (avaliable) {
			hours = CheckAppointmentTime(myAppointment);
			if (hours) {
				days = CheckAppointmentDay(myAppointment);
				if (days) {
					//let appointmentToEdit = `{"appointmentId":"${appointmentId}", "customerName":"${customerName}", "appointmentDate":"${appointmentDate}", "startTime":"${startTime}", "endTime":"${endTime}", "appointmentTypeId":"${appointmentTypeId}", "importanceId":"${importanceId}"}`;
					let appointmentToEdit = `{"customerName":"${customerName}", "appointmentDate":"${appointmentDate}", "startTime":"${startTime}", "endTime":"${endTime}", "appointmentTypeId":"${appointmentTypeId}", "importanceId":"${importanceId}"}`;
					if (event == "Update") {
						updateAppointment(appointmentToEdit, appointmentId).then(data => {
							getAppointments().then(data => {
								appointments = data;
								setAppointmentsTable(appointments, appointmentTypes, appointmentImportances);
							})
						});
					} else if (event == "Delete") {
						deleteAppointment(appointmentId).then(data => {
							if (data == 204) {
								getAppointments().then(data => {
									appointments = data;
									setAppointmentsTable(appointments, appointmentTypes, appointmentImportances);
								})
							};
						})
					} else {
						addAppointment(appointmentToEdit).then(data => {
							getAppointments().then(data => {
								appointments = data;
								setAppointmentsTable(appointments, appointmentTypes, appointmentImportances);
							})
						})
					}
				}
				else {
					throw new Error("The Day Is Not Avaliable");
				}
			}
			else {
				throw new Error("The Duration Is Not Avaliable");
			}
		}
		//else {
		//	throw new Error("The Time Is Not Avaliable");
		//}
	catch (error){
		alert(error);
	}
}

export function SearchByDates() {
	let startDate = document.getElementById("startDate").value;
	let endDate = document.getElementById("endDate").value;
	getAppointmentsByDates(startDate, endDate).then(data => {
		appointments = data;
		setAppointmentsTable(appointments, appointmentTypes, appointmentImportances);
	})
}

function CreateStartEndInputs(id) {
	let myInput = document.createElement("INPUT");
	myInput.setAttribute("type", "date");
	myInput.id = id;
	myInput.name = id;
	return myInput;
}

function CreateSearchButton() {
	let SearchBtn = document.createElement("button");
	SearchBtn.id = "SearchBtn";
	SearchBtn.onclick = SearchByDates;
	SearchBtn.innerHTML = 'Search By Dates';
	return SearchBtn;
}

function CreateHeaders(row) {
	let myHeaders = [
		"<b>Customer Name</b>",
		"<b>Appointment Date</b>",
		"<b>Appointment Day</b>",
		"<b>Start Time</b>",
		"<b>End Time</b>",
		"<b>Appointment Type</b>",
		"<b>Appointment Importance</b>",
		"<b>Edit Appointment</b>",
		"<b>Delete Appointment</b>"
	];

	for (let cellCounter = 0; cellCounter < myHeaders.length; cellCounter++) {
		let cell = row.insertCell(cellCounter);
		cell.innerHTML = myHeaders[cellCounter];
	}
}

function CreateInputType(cell, type, id, value, rowCounter, disabled) {
	let myInput = document.createElement("INPUT");
	myInput.setAttribute("type", type);
	myInput.id = id + rowCounter;

	if (value != null && value != "") {
		if (disabled == true) {
			let date = new Date(value);
			myInput.value = weekday[date.getDay()];
			myInput.disabled = disabled;
		} else if (type == "text") {
			myInput.value = value;
		} else if (type == "date") {
			let date = new Date(value);
			let currentDate = moment(date).format("YYYY-MM-DD");
			myInput.value = currentDate;
			myInput.onchange = function () {
				let date = new Date(myInput.value);
				document.getElementById("appointmentDay" + rowCounter).value = weekday[date.getDay()];
			}
		} else if (type == "time") {
			let dateForTime = new Date(value);
			let hours = dateForTime.getHours();
			let minutes = dateForTime.getMinutes();
			let seconds = dateForTime.getSeconds();
			if (hours < 10) hours = "0" + hours;
			if (minutes < 10) minutes = "0" + minutes;
			if (seconds < 10) seconds = "0" + seconds;
			let currentTime = hours + ':' + minutes + ':' + seconds;
			myInput.value = currentTime;
			//myInput.onchange = function () {
			//	alert(document.getElementById("startTime" + rowCounter).value);
			//	alert(document.getElementById("endTime" + rowCounter).value);
			//	document.getElementById("endTime" + rowCounter).min = document.getElementById("startTime" + rowCounter).value;
			//}
		}
	} else {
		if (disabled == true) {
			myInput.disabled = disabled;
		} else if (type == "date") {
			myInput.onchange = function () {
				let date = new Date(myInput.value);
				document.getElementById("appointmentDay" + rowCounter).value = weekday[date.getDay()];
			}
		}
	}
	cell.appendChild(myInput);
}

function CreateInputs(row, rowCounter, appointment) {
	let myInputs = [
		{ type: "text", id: "customerName", rowCounter: rowCounter, value: appointment.customerName, disabled:false },
		{ type: "date", id: "appointmentDate", rowCounter: rowCounter, value: appointment.appointmentDate, disabled: false },
		{ type: "text", id: "appointmentDay", rowCounter: rowCounter, value: appointment.appointmentDate, disabled:true },
		{ type: "time", id: "startTime", rowCounter: rowCounter, value: appointment.startTime, disabled: false },
		{ type: "time", id: "endTime", rowCounter: rowCounter, value: appointment.endTime, disabled: false }
	];
	for (var cellCounter = 0; cellCounter < myInputs.length; cellCounter++) {
		let cell = row.insertCell(cellCounter);
		CreateInputType(cell, myInputs[cellCounter].type, myInputs[cellCounter].id, myInputs[cellCounter].value, rowCounter, myInputs[cellCounter].disabled);
	}
	return cellCounter;
}

function CreateLists(rowCounter, id, name, optionDisText, appointment, types, importances, cellCounter, row) {
	let selectList = document.createElement("select");
	selectList.id = id + rowCounter;
	selectList.name = name + rowCounter;
	selectList.style.width = "100%";
	selectList.border = '0';

	let optionDis = document.createElement("option");
	optionDis.value = '';
	optionDis.text = optionDisText;
	optionDis.disabled = true;
	if (appointment == null || appointment == "") {
		optionDis.selected = true;
	}
	selectList.appendChild(optionDis);

	if (types != null) {
		for (let rowCounter = 0; rowCounter < appointmentTypes.length; rowCounter++) {
			let option = document.createElement("option");
			option.value = types[rowCounter].appointmentTypeId;
			option.text = types[rowCounter].appointmentTypeName;
			selectList.appendChild(option);
		}
	}

	if (importances != null) {
		for (let rowCounter = 0; rowCounter < appointmentImportances.length; rowCounter++) {
			let option = document.createElement("option");
			option.value = importances[rowCounter].importanceId;
			option.text = importances[rowCounter].importanceName;
			selectList.appendChild(option);
		}
	}

	let cell = row.insertCell(cellCounter);
	cell.appendChild(selectList);

	if (types != null) {
		if (appointment != null && appointment != "") {
			selectList.value = appointment.appointmentTypeId;
		}
	}
	
	if (importances != null) {
		if (appointment != null && appointment != "") {
			selectList.value = appointment.importanceId;
		}
	}
}

function CreateButton(rowCounter, appointment, row, cellCounter, event) {
	let AppointmentBtn = document.createElement("button");
	AppointmentBtn.id = "AppointmentBtn" + event + rowCounter;
	AppointmentBtn.onclick = function () {
		EditAppointmentTable(rowCounter, event);
	}
	AppointmentBtn.style.width = "100%";
	AppointmentBtn.value = appointment.appointmentId;
	if (event == "Update") {
		AppointmentBtn.innerHTML = 'Update Appointment';
		let cell = row.insertCell(cellCounter);
		cell.appendChild(AppointmentBtn);
	} else if (event == "Delete") {
		AppointmentBtn.innerHTML = 'Delete Appointment';
		let cell = row.insertCell(cellCounter);
		cell.appendChild(AppointmentBtn);
	} else {
		AppointmentBtn.innerHTML = 'Add Appointment';
		let cell = row.insertCell(cellCounter);
		cell.colSpan = "2";
		cell.appendChild(AppointmentBtn);
	}
}

function OneAppointment(appointment, table, rowCounter) {
	let row = table.insertRow(rowCounter);

	if (appointment == "" && rowCounter == 0) {
		CreateHeaders(row);
	} else {
		let cellCounter = CreateInputs(row, rowCounter, appointment);

		let id = "appointmentTypeName";
		let name = 'appointmentTypeName';
		let optionDisText = 'Select your type';
		CreateLists(rowCounter, id, name, optionDisText, appointment, appointmentTypes, null, cellCounter, row);
		cellCounter++;

		id = "appointmentImportancesName";
		name = 'appointmentImportancesName';
		optionDisText = 'Select your importance';
		CreateLists(rowCounter, id, name, optionDisText, appointment, null, appointmentImportances, cellCounter, row);
		cellCounter++;
		if (appointment != "") {
			CreateButton(rowCounter, appointment, row, cellCounter, "Update");
			cellCounter++;
			CreateButton(rowCounter, appointment, row, cellCounter, "Delete");
		} else {
			CreateButton(rowCounter, appointment, row, cellCounter, "Add");
        }
	}
}

function AppointmentsList() {
	let table = document.createElement("TABLE");
	table.id = "AppointmentsTable";
	table.border = '1';
	let rowCounter = 0;
	OneAppointment("", table, rowCounter);
	if (appointments != null && appointments != "") {
		for (rowCounter = 0; rowCounter < appointments.length; rowCounter++) {
			OneAppointment(appointments[rowCounter], table, rowCounter + 1);
		}
	}
	rowCounter++;
	OneAppointment("", table, rowCounter);
	return table;
}