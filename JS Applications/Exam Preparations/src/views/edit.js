import { html } from "../lib.js";
import { getOfferById, editOffer } from "../api/data.js";
import { createSubmitHandler } from "../util.js";

const editTemplate = (offer, onEdit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Offer</h2>
        <form @submit=${onEdit} class="edit-form">
            <input type="text" name="title" id="job-title" placeholder="Title" .value=${offer.title} />
            <input type="text" name="imageUrl" id="job-logo" placeholder="Company logo url" .value=${offer.imageUrl} />
            <input type="text" name="category" id="job-category" placeholder="Category" .value=${offer.category} />
            <textarea id="job-description" name="description" placeholder="Description" .value=${offer.description} rows="4" cols="50"></textarea>
            <textarea id="job-requirements" name="requirements" placeholder="Requirements" .value=${offer.requirements} rows="4"
                cols="50"></textarea>
            <input type="text" name="salary" id="job-salary" placeholder="Salary" .value=${offer.salary} />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

export async function editView(ctx) {
    const id = ctx.params.id;
    const offer = await getOfferById(id);

    ctx.render(editTemplate(offer, createSubmitHandler(onEdit)));

    async function onEdit({ title, imageUrl, category, description, requirements, salary }) {
        if (title == '' || imageUrl == '' || category == '' || description == ''
            || requirements == '' || salary == '') {
            return alert('All fields are required!');
        }

        await editOffer(id, {
            title,
            imageUrl,
            category,
            description,
            requirements,
            salary
        });

        ctx.page.redirect('/catalog/' + id);
    }
}   