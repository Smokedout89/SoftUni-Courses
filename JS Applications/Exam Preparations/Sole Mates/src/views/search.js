import { html, nothing } from "../lib.js";
import { searchSneaker } from "../api/data.js";

const searchTemplate = (isClicked, onSearch, sneakers, hasUser) => html`
<section id="search">
    <h2>Search by Brand</h2>

    <form @submit=${e => onSearch(e)} class="search-wrapper cf">
        <input id="#search-input" type="text" name="search" placeholder="Search here..." required />
        <button type="submit">Search</button>
    </form>

    <h3>Results:</h3>

    <div id="search-container">
        <ul class="card-wrapper">
            ${isClicked 
            ? sneakers.length > 0
            ? sneakers.map(sneaker => sneakerCard(sneaker, hasUser))
            : html`<h2>There are no results found.</h2>`
            : nothing }
        </ul>       
    </div>
</section>`;

const sneakerCard = (sneaker, hasUser) => html`
<li class="card">
    <img src=${sneaker.imageUrl} alt="" />
    <p>
        <strong>Brand: </strong><span class="brand">${sneaker.brand}</span>
    </p>
    <p>
        <strong>Model: </strong><span class="model">${sneaker.model}</span>
    </p>
    <p><strong>Value:</strong><span class="value">${sneaker.value}</span>$</p>
    ${hasUser 
    ? html`<a class="details-btn" href="/catalog/${sneaker._id}">Details</a>`
    : nothing}
</li>`;

export function searchView(ctx) {
    ctx.render(searchTemplate(false, onSearch));
    
    async function onSearch(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
        const query = formData.get('search').trim();

        if (!query) {
            return alert('Please enter text to search!');
        }
        
        const sneakers = await searchSneaker(query);
        ctx.render(searchTemplate(true, onSearch, sneakers, ctx.user));
    }
}