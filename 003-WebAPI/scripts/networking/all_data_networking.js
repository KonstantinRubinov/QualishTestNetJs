import { alldataUrl } from './links.js';

export function getAllData() {
    return fetch(alldataUrl)
        .then(function (response) {
            if (response.status == 200) {
                return response.text();
            } else {
                throw new Error("Can't Get All Data");
            }
        })
        .then(function (data) {
            let jsonData = JSON.parse(data);
            console.log("getAllData", jsonData);
            return jsonData;
        })
        .catch((error) => {
            alert(error)
        });
}