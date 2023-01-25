import { html, nothing } from "../lib.js";
import { deleteSneakerById, getSneakerById } from "../api/data.js";

const detailsTemplate = (sneaker, isOwner, onDelete) => html`
<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Shoe Details</p>
        <div id="img-wrapper">
            <img src=${sneaker.imageUrl} alt="" />
        </div>
        <div id="info-wrapper">
            <p>Brand: <span id="details-brand">${sneaker.brand}</span></p>
            <p>
                Model: <span id="details-model">${sneaker.model}</span>
            </p>
            <p>Release date: <span id="details-release">${sneaker.release}</span></p>
            <p>Designer: <span id="details-designer">${sneaker.designer}</span></p>
            <p>Value: <span id="details-value">${sneaker.value}</span></p>
        </div>

        ${isOwner 
        ? html`
        <div id="action-buttons">
            <a href="/edit/${sneaker._id}" id="edit-btn">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>
        </div>`
        : nothing }
        
    </div>
</section>`;

export async function detailsView(ctx) {
    const sneaker = await getSneakerById(ctx.params.id);
    const hasUser = Boolean(ctx.user);
    const isOwner = hasUser && ctx.user._id == sneaker._ownerId;

    ctx.render(detailsTemplate(sneaker, isOwner, onDelete));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this pet?');

        if (choice) {
            await deleteSneakerById(sneaker._id);
            ctx.page.redirect('/catalog');
        }
    }
}