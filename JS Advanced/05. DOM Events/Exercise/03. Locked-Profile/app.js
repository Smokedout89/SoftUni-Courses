function lockedProfile() {
    const buttons = document.querySelectorAll('button');

    for (const button of buttons) {
        button.addEventListener('click', showMore);
    }

    function showMore(event) {
        const profile = event.target.parentElement;
        const radioButton = profile.querySelector('input[type="radio"]');

        if (!radioButton.checked) {
           const div = profile.querySelector('div');

           if (event.target.textContent == 'Show more') {
                div.style.display = 'block';
                event.target.textContent = 'Hide it';
           } else {
               div.style.display = 'none';
               event.target.textContent = 'Show more';
           }      
        }
    }
}