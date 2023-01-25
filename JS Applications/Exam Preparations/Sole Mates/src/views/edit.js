import { html } from "../lib.js";
import { getSneakerById, editSneaker } from "../api/data.js";
import { createSubmitHandler } from "../util.js";

const editTemplate = (sneaker, onEdit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit item</h2>
        <form @submit=${onEdit} class="edit-form">
            <input type="text" name="brand" id="shoe-brand" placeholder="Brand" .value=${sneaker.brand} />
            <input type="text" name="model" id="shoe-model" placeholder="Model" .value=${sneaker.model} />
            <input type="text" name="imageUrl" id="shoe-img" placeholder="Image url" .value=${sneaker.imageUrl} />
            <input type="text" name="release" id="shoe-release" placeholder="Release date" .value=${sneaker.release} />
            <input type="text" name="designer" id="shoe-designer" placeholder="Designer" .value=${sneaker.designer} />
            <input type="text" name="value" id="shoe-value" placeholder="Value" .value=${sneaker.value} />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

export async function editView(ctx) {
    const id = ctx.params.id;
    const sneaker = await getSneakerById(id);

    ctx.render(editTemplate(sneaker, createSubmitHandler(onEdit)));

    async function onEdit({ brand, model, imageUrl, release, designer, value }) {
        if (brand == '' || model == '' || imageUrl == '' || release == ''
            || designer == '' || value == '') {
            return alert('All fields are required!');
        }

        await editSneaker(id, {
            brand,
            model,
            imageUrl,
            release,
            designer,
            value
        });

        ctx.page.redirect('/catalog/' + id);
    }
}