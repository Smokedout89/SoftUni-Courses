import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { updateNav } from './views/nav.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { registerView } from './views/register.js';
import { catalogView } from './views/catalog.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { createView } from './views/create.js';
import { searchView } from './views/search.js';

const main = document.getElementById('main-content');

page(decorateContext);
page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/catalog', catalogView);
page('/catalog/:id', detailsView);
page('/create', createView);
page('/edit/:id', editView);
page('/search', searchView);

updateNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    const user = getUserData();

    if (user) {
        ctx.user = user;
    }

    next();
}

function renderMain(content) {
    render(content, main);
}