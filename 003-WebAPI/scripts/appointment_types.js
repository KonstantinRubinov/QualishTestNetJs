import { addAppointmentType, updateAppointmentType, deleteAppointmentType } from './networking/appointment_type_networking.js';
import { getAllMyData } from './main.js';
import { AppointmentTypeModel } from './model/appointment_type_model.js';

var appointmentTypes;

export function setTypesTable(tmpAppointmentTypes) {

    appointmentTypes = [];

    if (Array.isArray(tmpAppointmentTypes)) {
        tmpAppointmentTypes.forEach((appointmentTypeModel) => appointmentTypes.push(new AppointmentTypeModel(appointmentTypeModel.appointmentTypeId, appointmentTypeModel.appointmentTypeName)));
    } else {
        appointmentTypes.push(new AppointmentTypeModel(tmpAppointmentTypes.appointmentTypeId, tmpAppointmentTypes.appointmentTypeName));
    }

    if (document.getElementById('AppointmentTypesTable') != null) {
        document.getElementById("appointmentType").replaceChild(AppointmentTypesList(), document.getElementById('AppointmentTypesTable'));
    } else {
        document.getElementById("appointmentType").appendChild(AppointmentTypesList());
    }
    document.getElementById("AppointmentTypesTable").style.textAlign = "center";
}

function editType(rowCounter, event) {
    let appointmentTypeId = document.getElementById('appTypeBtn' + event + rowCounter).value;
    let appointmentTypeName = document.getElementById('appTypeName' + rowCounter).value;
    let appointmentTypeToEdit = `{"appointmentTypeName":"${appointmentTypeName}"}`;
    if (event == "Update") {
        updateAppointmentType(appointmentTypeToEdit, appointmentTypeId).then(data => {
            getAllMyData();
        })
    } else if (event == "Delete") {
        deleteAppointmentType(appointmentTypeId).then(data => {
            if (data == 204) {
                getAllMyData();
            }
        })
    } else {
        addAppointmentType(appointmentTypeToEdit).then(data => {
            getAllMyData();
        })
    }
}

function CreateHeaders(row) {
    let myHeaders = [
        "<b>Appointment Type Name</b>",
        "<b>Edit Appointment Type</b>",
        "<b>Delete Appointment Type</b>"
    ];

    for (let cellCounter = 0; cellCounter < myHeaders.length; cellCounter++) {
        let cell = row.insertCell(cellCounter);
        cell.innerHTML = myHeaders[cellCounter];
    }
}

function CreateInput(cell, appointmentType, rowCounter) {
    let appointmentTypeNameTo = document.createElement("INPUT");
    appointmentTypeNameTo.setAttribute("type", "text");
    appointmentTypeNameTo.id = "appTypeName" + rowCounter;
    if (appointmentType != null && appointmentType != "") {
        appointmentTypeNameTo.value = appointmentType.appointmentTypeName;
    }
    cell.appendChild(appointmentTypeNameTo);
}

function CreateButton(cell, appointmentType, rowCounter, event) {
    let setTypeBtn = document.createElement("button");
    setTypeBtn.id = "appTypeBtn" + event + rowCounter;
    setTypeBtn.onclick = function () {
        editType(rowCounter, event);
    };
    setTypeBtn.style.width = "100%";
    if (event == "Update") {
        setTypeBtn.innerHTML = 'Update Type';
    } else if (event == "Delete"){
        setTypeBtn.innerHTML = 'Delete Type';
    } else {
        setTypeBtn.innerHTML = 'Add Type';
    }
    setTypeBtn.value = appointmentType.appointmentTypeId;
    cell.appendChild(setTypeBtn);
}

function OneAppointmentType(appointmentType, table, rowCounter) {
    let row = table.insertRow(rowCounter);
    if (rowCounter == 0) {
        CreateHeaders(row);
    } else {
        let cell1 = row.insertCell(0);
        CreateInput(cell1, appointmentType, rowCounter);

        if (appointmentType != "") {
            let cell2 = row.insertCell(1);
            CreateButton(cell2, appointmentType, rowCounter, "Update");

            let cell3 = row.insertCell(2);
            CreateButton(cell3, appointmentType, rowCounter, "Delete");
        } else {
            let cell4 = row.insertCell(1);
            cell4.colSpan = "2";
            CreateButton(cell4, appointmentType, rowCounter, "Add");
        }
    }
}

function AppointmentTypesList() {
    let table = document.createElement("TABLE");
    table.id = "AppointmentTypesTable";
    table.border = '1';
    let rowCounter = 0;
    OneAppointmentType("", table, rowCounter);
    if (appointmentTypes != null && appointmentTypes != "") {
        for (rowCounter = 0; rowCounter < appointmentTypes.length; rowCounter++) {
            OneAppointmentType(appointmentTypes[rowCounter], table, rowCounter + 1);
        }
    }
    rowCounter++;
    OneAppointmentType("", table, rowCounter);
    return table;
}