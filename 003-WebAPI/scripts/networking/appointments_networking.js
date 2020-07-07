import { appointmentsUrl } from './links.js';

export function getAppointments() {
    return fetch(appointmentsUrl)
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Get Appointments");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("getAppointments", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

//export function getAppointmentsByDate(currentDate){
//    return fetch(appointmentsUrl + currentDate)
//        .then(function (response) {
//            if (response.status == 200) {
//                return response.text();
//            } else {
//                throw new Error("Can't Get Appointments By Date");
//            }
//        })
//        .then(function (data) {
//            let jsonData = JSON.parse(data);
//            console.log("getAppointmentsByDate", jsonData);
//            return jsonData;
//        })
//        .catch((error) => {
//            alert(error)
//        });
//}


export function getAppointmentsByDates(startDate, endDate) {
    let theUrl = appointmentsUrl + startDate + '/' + endDate;
    
    if (startDate != "" && endDate == "") {
        theUrl = appointmentsUrl + 'start/' + startDate;
    }
    if (endDate != "" && startDate == "") {
        theUrl = appointmentsUrl + 'end/' + endDate;
    }

    return fetch(theUrl)
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Get Appointments By Dates");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("getAppointmentsByDates", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function getAppointmentById(appointmentId) {
    return fetch(appointmentsUrl + appointmentId)
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Get Appointments By Id");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("getAppointmentById", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function addAppointment(appointmentToAdd) {
    console.log("addAppointment", appointmentToAdd);
    return fetch(appointmentsUrl,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'POST',
            body: appointmentToAdd
        })
        .then(function (response) {
            if (response.status == 201) {
                alert("Appointment has been Added");
                return response.text();
            } else {
                throw new Error("Can't Add Appointments");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("addAppointment", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function updateAppointment(appointmentToUpdate, appointmentId) {
    console.log("updateAppointment", appointmentToUpdate);
    return fetch(appointmentsUrl + appointmentId,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'PUT',
            body: appointmentToUpdate
        })
        .then(function (response) {
            if (response.status == 200) {
                alert("Appointment has been Updated");
                return response.text();
            } else {
                throw new Error("Can't Update Appointments");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("updateAppointment", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}

export function deleteAppointment(appointmentId) {
    console.log("deleteAppointment", appointmentId);
    return fetch(appointmentsUrl + appointmentId,
        {
            headers:
            {
                'content-type': 'application/json'
            },
            method: 'DELETE'
        })
        .then(function (response) {
            if (response.status == 204) {
                alert("Appointment has been Deleted");
                return response.status;
            } else {
                throw new Error("Can't Delete Appointment");
            }
        })
        .catch((error) => {
            alert(error)
        });
}