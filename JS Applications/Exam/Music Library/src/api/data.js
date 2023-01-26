import { get, del, post, put } from "./api.js";

export async function getAllAlbums() {
    return get('/data/albums?sortBy=_createdOn%20desc');
}

export async function getAlbumById(id) {
    return get('/data/albums/' + id);
}

export async function deleteAlbumById(id) {
    return del('/data/albums/' + id);
}

export async function createAlbum(albumData) {
    return post('/data/albums', albumData);
}

export async function editAlbum(id, albumData) {
    return put('/data/albums/' + id, albumData);
}