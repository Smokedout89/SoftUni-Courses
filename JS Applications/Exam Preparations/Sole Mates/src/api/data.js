import { get, del, post, put } from "./api.js";

export async function getAllSneakers() {
    return get('/data/shoes?sortBy=_createdOn%20desc');
}

export async function getSneakerById(id) {
    return get('/data/shoes/' + id);
}

export async function deleteSneakerById(id) {
    return del('/data/shoes/' + id);
}

export async function createSneakerPair(sneakerData) {
    return post('/data/shoes', sneakerData);
}

export async function editSneaker(id, sneakerData) {
    return put('/data/shoes/' + id, sneakerData);
}

export async function searchSneaker(query) {
    return get(`/data/shoes?where=brand%20LIKE%20%22${query}%22`);
}