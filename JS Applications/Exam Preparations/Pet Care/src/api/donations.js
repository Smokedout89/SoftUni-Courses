import { get, post } from "./api.js";

export async function donate(petId) {
    return post('/data/donation', {
        petId
    });
}

export async function getDonations(petId) {
    return get(`/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`);
}

export async function getOwnDonations(petId, userId) {
    return get(`/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}