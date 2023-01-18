import { clearUserData, setUserData } from "../utils.js";
import { get, post } from "./api.js";

export async function login(email, password) {
    const result = await post('/users/login', { email, password });

    const userData = {
        id: result._id,
        username: result.username,
        email: result.email,
        gender: result.gender,
        accessToken: result.accessToken
    }

    setUserData(userData);

    return result;
}

export async function register(username, email, password, gender) {
    const result = await post('/users/register', { username, email, password, gender });

    const userData = {
        id: result._id,
        username: result.username,
        email: result.email,
        gender: result.gender,
        accessToken: result.accessToken
    }

    setUserData(userData);

    return result;
}

export function logout() {
    get('/users/logout');
    clearUserData();
}