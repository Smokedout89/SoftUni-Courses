import { deleteById, getById } from "../api/data.js";
import { donate, getDonations, getOwnDonations } from "../api/donations.js";
import { html, nothing } from "../lib.js";

const detailsTemplate = (pet, donations, hasUser, canDonate, isOwner, onDelete, onDonate) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: ${donations}$</h4>
            </div>
            ${petControls(pet, hasUser, canDonate, isOwner, onDelete, onDonate)}
        </div>
    </div>
</section>`;

function petControls(pet, hasUser, canDonate, isOwner, onDelete, onDonate) {
    if (hasUser == false) {
        return nothing;
    }

    if (canDonate) {
        return html`
        <div class="actionBtn">
            <a @click=${onDonate} href="javascript:void(0)" class="donate">Donate</a>
        </div>`;
    }

    if (isOwner) {
        return html`
        <div class="actionBtn">
            <a href="/edit/${pet._id}" class="edit">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a> 
        </div>`;
    }
}

export async function detailsView(ctx) {
    const id = ctx.params.id;

    const requests = [
        getById(id),
        getDonations(id)
    ];

    const hasUser = Boolean(ctx.user);

    if (hasUser) {
        requests.push(getOwnDonations(id, ctx.user._id));
    }

    const [pet, donations, hasDonations] = await Promise.all(requests);

    const isOwner = hasUser && ctx.user._id == pet._ownerId;
    const canDonate = !isOwner && hasDonations == 0;
  
    ctx.render(detailsTemplate(pet, donations * 100, hasUser, canDonate, isOwner, onDelete, onDonate));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this pet?');

        if (choice) {
            await deleteById(id);
            ctx.page.redirect('/');
        }
    }

    async function onDonate() {
        await donate(id);
        ctx.page.redirect('/catalog/' + id);
    }
}