import { appointmentImportancesUrl } from './links.js';

export function getAppointmentImportances() {
    return fetch(appointmentImportancesUrl)
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Get Appointment Importances");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("getAppointmentImportances", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function getAppointmentImportanceById(importanceId) {
    return fetch(appointmentImportancesUrl + importanceId)
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Get Appointment Importance By Id");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("getAppointmentImportanceById", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function addAppointmentImportances(appointmentImportanceToAdd) {
    console.log("addAppointmentImportances", appointmentImportanceToAdd);
    return fetch(appointmentImportancesUrl,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'POST',
            body: appointmentImportanceToAdd
        })
        .then(function (response) {
            if (response.status == 201) {
                return response.text();
            } else {
                throw new Error("Can't Add Appointment Importances");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("addAppointmentImportances", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function updateAppointmentImportances(appointmentImportanceToUpdate) {
    console.log("updateAppointmentImportances", appointmentImportanceToUpdate);
    return fetch(appointmentImportancesUrl + appointmentImportanceToUpdate.importanceId,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'PUT',
            body: appointmentImportanceToUpdate
        })
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Update Appointment Importances");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("updateAppointmentImportances", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function deleteAppointmentImportances(importanceId) {
    console.log("deleteAppointmentImportances", importanceId);
    return fetch(appointmentImportancesUrl + importanceId,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'DELETE'
        })
        .then(function (response) {
            if (response.status == 204) {
                return response.status;
            } else {
                throw new Error("Can't Delete Appointment Importance");
            }
        })
        .catch((error) => {
            alert(error)
        });
}