window.addEventListener("load", solve);

function solve() {
    const input = {
         title: document.getElementById('post-title'),
         category: document.getElementById('post-category'),
         content: document.getElementById('post-content')
    };

    const lists = {
        reviewLi: document.getElementById('review-list'),
        publishedLi: document.getElementById('published-list')
    };

    document.getElementById('publish-btn').addEventListener('click', publish);
    document.getElementById('clear-btn').addEventListener('click', clear);

    function publish(event) {
        event.preventDefault();

        const title = input.title.value;
        const category = input.category.value;
        const content = input.content.value;

        if (title === '' || category === '' || content === '') {
            return;
        }

        const liElement = document.createElement('li');
        liElement.className = 'rpost';
        liElement.innerHTML =
            `<article> 
             <h4>${title}</h4>
             <p>Category: ${category}</p>
             <p>Content: ${content}</p>   
            </article>
            <button class="action-btn edit">Edit</button>
            <button class="action-btn approve">Approve</button>`;

        const editBtn = liElement.querySelector('.edit');
        const approveBtn = liElement.querySelector('.approve');

        editBtn.addEventListener('click', edit);
        approveBtn.addEventListener('click', approve);

        lists.reviewLi.appendChild(liElement);

        input.title.value = '';
        input.category.value = '';
        input.content.value = '';

        function edit() {
            input.title.value = title;
            input.category.value = category;
            input.content.value = content;

            liElement.remove();
        }

        function approve() {
            lists.publishedLi.appendChild(liElement);

            editBtn.remove();
            approveBtn.remove();
        }
    }

    function clear() {
        lists.publishedLi.innerHTML = '';
    }
}