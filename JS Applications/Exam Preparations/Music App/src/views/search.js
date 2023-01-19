import { searchAlbums } from "../api/data.js";
import { html, nothing } from "../lib.js";

const searchTemplate = (isClicked, onSearch, albums, hasUser) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button @click=${onSearch} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
        <div class="search-result">
            ${isClicked 
                ? albums.length > 0 
                ? html`${albums.map(album => albumCard(album, hasUser))}`
                : html`<p class="no-result">No result.</p>`
                : nothing}        
        </div>
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

export async function searchView(ctx) {
    ctx.render(searchTemplate(false, onSearch));

    async function onSearch(e) {
        const searchInput = document.getElementById('search-input');
        const query = searchInput.value;

        if (!query) {
            return alert('Please enter text to search!');
        }

        const albums = await searchAlbums(query);
        ctx.render(searchTemplate(true, onSearch, albums, ctx.user));
    }
}