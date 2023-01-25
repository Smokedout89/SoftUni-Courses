import { html } from "../lib.js";
import { getAllSneakers } from "../api/data.js";

const catalogTemplate = (sneakers) => html`
<section id="dashboard">
    <h2>Collectibles</h2>
    <ul class="card-wrapper">
        ${sneakers.length == 0 
        ? html` <h2>There are no items added yet.</h2>`
        : html`${sneakers.map(sneakerCardTemplate)}`}
    </ul>
</section>`;

const sneakerCardTemplate = (sneaker) => html`
<li class="card">
    <img src=${sneaker.imageUrl} alt="" />
    <p>
        <strong>Brand: </strong><span class="brand">${sneaker.brand}</span>
    </p>
    <p>
        <strong>Model: </strong><span class="model">${sneaker.model}</span>
    </p>
    <p><strong>Value:</strong><span class="value">${sneaker.value}</span>$</p>
    <a class="details-btn" href="/catalog/${sneaker._id}">Details</a>
</li>`;

export async function catalogView(ctx) {
    const sneakers = await getAllSneakers();
    ctx.render(catalogTemplate(sneakers));
}