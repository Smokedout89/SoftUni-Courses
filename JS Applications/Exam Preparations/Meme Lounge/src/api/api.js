import { notify } from "../notify.js";
import { clearUserData, getUserData } from "../utils.js";

const host = 'http://localhost:3030';

async function request(url, method, data) {
    const options = {
        method,
        headers: {}
    }

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const userData = getUserData();

    if (userData) {
        options.headers['X-Authorization'] = userData.accessToken;
    }

    try {
        const response = await fetch(host + url, options);

        if (response.ok == false) {
            if (response.status == 403) {
                clearUserData();
            }
            const error = await response.json();
            throw new Error(error.message);
        }

        if (response.status == 204) {
            return response;
        } else {
            return response.json();
        }
    } catch (error) {
        notify(error.message);
        throw error;
    }
}

export async function get(url) {
    return request(url, 'GET');
}

export async function post(url, data) {
    return request(url, 'POST', data);
}

export async function put(url, data) {
    return request(url, 'PUT', data);
}

export async function del(url) {    
    return request(url, 'DELETE');
}