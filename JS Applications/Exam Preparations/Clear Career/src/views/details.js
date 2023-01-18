import { html, nothing } from "../lib.js";
import { apply, getApplications, getOwnApplications } from "../api/apply.js";
import { getOfferById, deleteOfferById } from "../api/data.js";

const detailsTemplate = (offer, applications, hasUser, canApply, isOwner, onDelete, onApply) => html`
<section id="details">
    <div id="details-wrapper">
        <img id="details-img" src=${offer.imageUrl} alt="" />
        <p id="details-title">${offer.title}</p>
        <p id="details-category">
            Category: <span id="categories">${offer.category}</span>
        </p>
        <p id="details-salary">
            Salary: <span id="salary-number">${offer.salary}</span>
        </p>
        <div id="info-wrapper">
            <div id="details-description">
                <h4>Description</h4>
                <span>${offer.description}</span>
            </div>
            <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${offer.requirements}</span>
            </div>
        </div>
        <p>Applications: <strong id="applications">${applications}</strong></p>
        ${offerControls(offer, hasUser, canApply, isOwner, onDelete, onApply)}
    </div>
</section>`;

function offerControls(offer, hasUser, canApply, isOwner, onDelete, onApply) {
    if (!hasUser) {
        return nothing;
    }

    if (isOwner) {
        return html`
        <div id="action-buttons">
            <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>
        </div>`;
    }

    if (canApply) {
        return html`
        <div id="action-buttons">
            <a @click=${onApply} href="javascript:void(0)" id="apply-btn">Apply</a>
        </div>`;  
    }
}

export async function detailsView(ctx) {
    const id = ctx.params.id;

    const requests = [
        getOfferById(id),
        getApplications(id)
    ];

    const hasUser = Boolean(ctx.user);

    if (hasUser) {
        requests.push(getOwnApplications(id, ctx.user._id));
    }

    const [offer, applications, hasApplied] = await Promise.all(requests);

    const isOwner = hasUser && ctx.user._id == offer._ownerId;
    const canApply = hasUser && hasApplied == 0;

    ctx.render(detailsTemplate(offer, applications, hasUser, canApply, isOwner, onDelete, onApply));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this offer?');

        if (choice) {
            await deleteOfferById(id);
            ctx.page.redirect('/catalog');
        }
    }

    async function onApply() {
        await apply(id);
        ctx.page.redirect('/catalog/' + id);
    }
}