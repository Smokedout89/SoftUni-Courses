import { html, nothing } from "../lib.js";
import { getAllAlbums } from "../api/data.js";

const catalogTemplate = (albums, hasUser) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
    ${albums.length == 0 
    ? html`<p>No Albums in Catalog!</p>`
    : albums.map(album => albumCard(album, hasUser))}
</section>`;

const albumCard = (album, hasUser) => html`
<div class="card-box">
    <img src=${album.imgUrl}>
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: ${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>

        ${hasUser 
        ? html`
        <div class="btn-group">
            <a href="/catalog/${album._id}" id="details">Details</a>
        </div>`
        : nothing}       
    </div>
</div>`;

export async function catalogView(ctx) {
    const albums = await getAllAlbums();
    const hasUser = ctx.user;

    ctx.render(catalogTemplate(albums, hasUser));
}