window.addEventListener('load', solve);

function solve() {
    const input = {
        genre: document.querySelector('#genre'),
        name: document.querySelector('#name'),
        author: document.querySelector('#author'),
        date: document.querySelector('#date')
    }

    const collections = {
        allHits: document.querySelector('.all-hits-container'),
        savedHits: document.querySelector('.saved-container'),
        likes: document.querySelector('.likes')
    }

    const submitBtn = document.querySelector('#add-btn');
    submitBtn.addEventListener('click', addToCollection);
    let totalLikes = 0;

    function addToCollection(e) {
        e.preventDefault();

        const genre = input.genre.value;
        const name = input.name.value;
        const author = input.author.value;
        const date = input.date.value;

        if (genre === '' || name === '' || author === '' || date === '') {
            return;
        }

        const divElement = document.createElement('div');
        const imgElement = document.createElement('img');
        divElement.className = "hits-info";
        imgElement.src = "./static/img/img.png";

        divElement.appendChild(imgElement);
        divElement.appendChild(createElement('h2', `Genre: ${genre}`));
        divElement.appendChild(createElement('h2', `Name: ${name}`));
        divElement.appendChild(createElement('h2', `Author: ${author}`));
        divElement.appendChild(createElement('h3', `Date: ${date}`));
        divElement.appendChild(createElement('button', 'Save song', 'save-btn'));
        divElement.appendChild(createElement('button', 'Like song', 'like-btn'));
        divElement.appendChild(createElement('button', 'Delete', 'delete-btn'));

        collections.allHits.appendChild(divElement);

        const saveBtn = divElement.querySelector('.save-btn');
        const likeBtn = divElement.querySelector('.like-btn');
        const deleteBtn = divElement.querySelector('.delete-btn');

        likeBtn.addEventListener('click', likeSong);
        saveBtn.addEventListener('click', moveToSaved);
        deleteBtn.addEventListener('click', deleteSong);

        Object.values(input).forEach(v => v.value = '');

        function moveToSaved() {
            divElement.querySelector('.save-btn').remove();
            divElement.querySelector('.like-btn').remove();

            collections.savedHits.appendChild(divElement);
        }

        function deleteSong() {
            divElement.remove();
        }
    }

    function likeSong(e) {
        totalLikes += 1;
        collections.likes.querySelector('p').textContent = `Total Likes: ${totalLikes}`;

        e.currentTarget.disabled = true;
    }

    function createElement(type, content, className) {
        const element = document.createElement(type);
        element.textContent = content;
        if (className) {
            element.className = className;
        }

        return element;
    }
}