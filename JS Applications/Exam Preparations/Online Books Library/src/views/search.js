import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllBooks, searchBooks } from "../api/data.js";
import { bookPreview } from "./common.js";

const searchTemplate = (books, onSearch, params = '') => html`
<section id="search-page" class="dashboard">
    <h1>Search</h1>
    <form @submit=${onSearch}>
        <input type="text" name="search" value=${params}>
        <input type="submit" value="Search">
    </form>

    ${books.length == 0
    ? html`<p class="no-books">No results!</p>`
    : html`<ul class="other-books-list">${books.map(bookPreview)}</ul>`}
</section>`;

export async function searchPage(ctx) {
    const params = ctx.querystring.split('=')[1];
    let books = [];

    if (params) {
        books = await searchBooks(decodeURIComponent(params));
    } else {
        books = await getAllBooks();
    }

    ctx.render(searchTemplate(books, onSearch, params)); 

    function onSearch(e) {
        e.preventDefault();
        const formData = new FormData(e.target);
        const search = formData.get('search');

        if (search) {
            ctx.page.redirect('/search?query=' + encodeURIComponent(search));
        }
    }
}