function solve() {
    let correctAnswers = 0;

    const mapper = {
        'Question #1: Which event occurs when the user clicks on an HTML element?': 'onclick',
        'Question #2: Which function converting JSON to string?': 'JSON.stringify()',
        'Question #3: What is DOM?': 'A programming API for HTML and XML documents'
    }

    const questions = document.querySelectorAll('h2');
    let sectionElement = Array.from(document.querySelectorAll('section'));

    for (let i = 0; i < questions.length; i++) {
        let currentQuestion = questions[i].textContent;
        let buttons = sectionElement[i].querySelectorAll('p');
        
        for (const button of buttons) {
            button.addEventListener('click', answer);
        }
        
        function answer(event) {
            if (event.currentTarget.textContent === mapper[currentQuestion]) {
                correctAnswers++;
                if (i < 2) {
                    sectionElement[i].style.display = 'none';
                    sectionElement[i + 1].style.display = 'block';
                }
            } else {
                if (i < 2) {
                    sectionElement[i].style.display = 'none';
                    sectionElement[i + 1].style.display = 'block';
                }
            }

            if (i === 2) {
                let result = document.querySelector('.results-inner').children;

                if (correctAnswers === 3) {
                    result[0].textContent = "You are recognized as top JavaScript fan!";
                } else {
                    result[0].textContent = `You have ${correctAnswers} right answers`
                }

                sectionElement[i].style.display = 'none';
                document.getElementById('results').style.display = 'block';
            }
        }
    }
}