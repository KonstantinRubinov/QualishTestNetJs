import { appointmentTypesUrl } from './links.js';

export function getAppointmentTypes() {
    return fetch(appointmentTypesUrl)
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Get Appointment Types");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("getAppointmentTypes", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function getAppointmentTypesById(appointmentTypeId) {
    return fetch(appointmentTypesUrl + appointmentTypeId)
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Get Appointment Types By Id");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("getAppointmentTypesById", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function addAppointmentType(appointmentTypeToAdd) {
    console.log("addAppointmentType", appointmentTypeToAdd);
    return fetch(appointmentTypesUrl,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'POST',
            body: appointmentTypeToAdd
        })
        .then(function (response) {
            if (response.status == 201) {
                alert("Type has been Added");
                return response.text();
            } else {
                throw new Error("Can't Add Appointment Types");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("addAppointmentType", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function updateAppointmentType(appointmentTypeToUpdate, appointmentTypeId) {
    console.log("updateAppointmentType", appointmentTypeToUpdate);
    return fetch(appointmentTypesUrl + appointmentTypeId,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'PUT',
            body: appointmentTypeToUpdate
        })
        .then(function (response) {
            if (response.status == 200) {
                alert("Type has been Updated");
                return response.text();
            } else {
                throw new Error("Can't Update Appointment Types");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("updateAppointmentType", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function deleteAppointmentType(appointmentTypeId) {
    console.log("deleteAppointmentType", appointmentTypeId);
    return fetch(appointmentTypesUrl + appointmentTypeId,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'DELETE'
        })
        .then(function (response) {
            if (response.status == 204) {
                alert("Type has been Deleted");
                return response.status;
            } else {
                throw new Error("Can't Delete Appointment Types");
            }
        })
        .catch((error) => {
            alert(error)
        });
}