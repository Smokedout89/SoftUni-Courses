import { html } from "../lib.js";
import { getAllOffers } from "../api/data.js";

const catalogTemplate = (offers) => html`
<section id="dashboard">
    <h2>Job Offers</h2>

    ${offers.length == 0 
    ? html` <h2>No offers yet.</h2>`
    : offers.map(cardTempalte)}
</section>`;

const cardTempalte = (offer) => html`
<div class="offer">
    <img src="${offer.imageUrl}" alt="" />
    <p>
        <strong>Title: </strong><span class="title">${offer.title}</span>
    </p>
    <p><strong>Salary:</strong><span class="salary">${offer.salary}</span></p>
    <a class="details-btn" href="/catalog/${offer._id}">Details</a>
</div>`;

export async function catalogView(ctx) {
    const offers = await getAllOffers();
    ctx.render(catalogTemplate(offers));
}