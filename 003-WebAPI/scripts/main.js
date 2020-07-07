import { getAllData } from './networking/all_data_networking.js';
//import { getAppointmentImportances, getAppointmentImportanceById, addAppointmentImportances, updateAppointmentImportances, deleteAppointmentImportances } from './networking/appointment_importances_networking.js';
import { getAppointments, getAppointmentById, getAppointmentsByDates, addAppointment, updateAppointment, deleteAppointment } from './networking/appointments_networking.js';
//import { getAppointmentTypes, getAppointmentTypesById, addAppointmentType, updateAppointmentType, deleteAppointmentType } from './networking/appointment_type_networking.js';


import { setAppointmentsTable } from './appointments.js';
import { setTypesTable } from './appointment_types.js';

var appointmentImportances;
var appointmentTypes;
var appointments;

var appointmentImportance;
var appointmentType;
var appointment;

//-----------------------------------------------------Importance---------------------------------------------------------//

//export function getImportances() {
//    getAppointmentImportances().then(data => {
//        appointmentImportances = data;
//    })
//}

//export function getImportanceById(appointmentImportanceId) {
//    getAppointmentImportanceById(appointmentImportanceId).then(data => {
//        appointmentImportance = data;
//    })
//}

//export function addImportance(appointmentImportanceAdd) {
//    addAppointmentImportances(appointmentImportanceAdd).then(data => {
//        getAllMyData();
//    })
//}

//export function updateImportance(appointmentImportanceUpdate) {
//    updateAppointmentImportances(appointmentImportanceUpdate).then(data => {
//        getAllMyData();
//    })
//}

//export function deleteImportanceById(appointmentImportanceId) {
//    deleteAppointmentImportances(appointmentImportanceId).then(data => {
//        if (data == 204) {
//            getAllMyData();
//        };
//    })
//}

//-----------------------------------------------------Type--------------------------------------------------------------//

//export function getTypes(){
//    getAppointmentTypes().then(data => {
//        appointmentTypes = data;
//        setTypesTable(appointmentTypes);
//    })
//}

//export function getTypeById(appointmentTypeId) {
//    getAppointmentTypesById(appointmentTypeId).then(data => {
//        appointmentType = data;
//    })
//}

//export function addType(appointmentTypeAdd) {
//    addAppointmentType(appointmentTypeAdd).then(data => {
//        getAllMyData();
//    })
//}

//export function updateType(appointmentTypeUpdate, appointmentTypeId) {
//    updateAppointmentType(appointmentTypeUpdate, appointmentTypeId).then(data => {
//        getAllMyData();
//    })
//}

//export function deleteTypeById(appointmentTypeId) {
//    deleteAppointmentType(appointmentTypeId).then(data => {
//        if (data == 204) {
//            getAllMyData();
//        }
//    })
//}

//-----------------------------------------------------Appointment--------------------------------------------------------------//

//export function getApps(){
//    getAppointments().then(data => {
//        appointments = data;
//        setAppointmentsTable(appointments, appointmentTypes, appointmentImportances);
//    })
//}

//export function getAppsByDate(currentDate) {
//    getAppointmentsByDate(currentDate).then(data => {
//        appointments = data;
//        setAppointmentsTable(appointments, appointmentTypes, appointmentImportances);
//    })
//}

//export function getAppsByDates(startDate, endDate) {
//    getAppointmentsByDates(startDate, endDate).then(data => {
//        appointments = data;
//        setAppointmentsTable(appointments, appointmentTypes, appointmentImportances);
//    })
//}

//export function getAppById(appointmentId) {
//    getAppointmentById(appointmentId).then(data => {
//        appointment = data;
//    })
//}

//export function addApp(appointmentAdd) {
//    addAppointment(appointmentAdd).then(data => {
//        getApps();
//    })
//}

//export function updateApp(appointmentUpdate, appointmentTypeId) {
//    updateAppointment(appointmentUpdate, appointmentTypeId).then(data => {
//        getApps();
//    });
//}

//export function deleteAppById(appointmentId) {
//    deleteAppointment(appointmentId).then(data => {
//        if (data == 204) {
//            getApps();
//        };
//    })
//}

//-----------------------------------------------------AllData--------------------------------------------------------------//

export function getAllMyData() {
    getAllData().then(data => {
        appointmentImportances = data.appointmentImportances;
        appointmentTypes = data.appointmentTypes;
        appointments = data.appointments;
        setAppointmentsTable(appointments, appointmentTypes, appointmentImportances);
        setTypesTable(appointmentTypes);
    })
}
window.onload = getAllMyData;