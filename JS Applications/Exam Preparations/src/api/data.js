import { get, del, post, put } from "./api.js";

export async function getAllOffers() {
    return get('/data/offers?sortBy=_createdOn%20desc');
}

export async function getOfferById(id) {
    return get('/data/offers/' + id);
}

export async function deleteOfferById(id) {
    return del('/data/offers/' + id);
}

export async function createOffer(offerData) {
    return post('/data/offers', offerData);
}

export async function editOffer(id, offerData) {
    return put('/data/offers/' + id, offerData);
}