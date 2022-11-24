function create(words) {
   let content = document.getElementById('content');

   for (const word of words) {
      let div = document.createElement('div');
      let paragraph = document.createElement('p');
      paragraph.textContent = word;
      paragraph.style.display = 'none';
      div.appendChild(paragraph);

      div.addEventListener('click', onClick);
      content.appendChild(div);
   }

   function onClick(event) {
      event.currentTarget.children[0].style.display = '';
   }
}