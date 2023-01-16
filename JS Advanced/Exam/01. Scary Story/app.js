window.addEventListener("load", solve);

function solve() {
    const input = {
        firstName: document.querySelector('#first-name'),
        lastName: document.querySelector('#last-name'),
        age: document.querySelector('#age'),
        title: document.querySelector('#story-title'),
        genre: document.querySelector('#genre'),
        story: document.querySelector('#story')
    }

    const publishBtn = document.querySelector('#form-btn');
    publishBtn.addEventListener('click', publishStory);

    const previewList = document.querySelector('#preview-list');

    function publishStory() {
        const fname = input.firstName.value;
        const lname = input.lastName.value;
        const age = input.age.value;
        const title = input.title.value;
        const story = input.story.value;
        const genre = input.genre.value;

        if (fname === '' || lname === '' || age === '' || title === '' || story === '') {
            return;
        }

        const liElement = createElement('li', '', 'story-info');
        const articleElement = createElement('article', '');
        articleElement.appendChild(createElement('h4', `Name: ${fname} ${lname}`));
        articleElement.appendChild(createElement('p', `Age: ${age}`));
        articleElement.appendChild(createElement('p', `Title: ${title}`));
        articleElement.appendChild(createElement('p', `Genre: ${input.genre.value}`));
        articleElement.appendChild(createElement('p', `${story}`));

        liElement.appendChild(articleElement);
        liElement.appendChild(createElement('button', 'Save Story', `save-btn`));
        liElement.appendChild(createElement('button', 'Edit Story', `edit-btn`));
        liElement.appendChild(createElement('button', 'Delete Story', `delete-btn`));

        previewList.appendChild(liElement);
        publishBtn.disabled = true;
        
        const saveBtn = liElement.querySelector('.save-btn');
        const editBtn = liElement.querySelector('.edit-btn');
        const deleteBtn = liElement.querySelector('.delete-btn');
        
        editBtn.addEventListener('click', editStory);
        saveBtn.addEventListener('click', saveStory);
        deleteBtn.addEventListener('click', deleteStory);

        Object.values(input).forEach(v => v.value = '');
        
        function editStory() {
            input.firstName.value = fname;
            input.lastName.value = lname;
            input.age.value = age;
            input.title.value = title;
            input.story.value = story;
            input.genre.value = genre;

            publishBtn.disabled = false;
            liElement.remove();
        }
        
        function saveStory() {
            const divMain = document.querySelector('#main');
            divMain.innerHTML = '';

            divMain.appendChild(createElement('h1', `Your scary story is saved!`));
        }
        
        function deleteStory() {
            liElement.remove();
            publishBtn.disabled = false;
        }
    }

    function createElement(type, contest, className) {
        const element = document.createElement(type);
        element.textContent = contest;
        if (className) {
            element.className = className;
        }

        return element;
    }
}