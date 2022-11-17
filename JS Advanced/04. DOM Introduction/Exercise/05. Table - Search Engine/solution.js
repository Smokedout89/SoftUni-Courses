function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   let personInfo = document.querySelectorAll('tbody tr');
   let searched = document.getElementById('searchField');

   function onClick() {
      for (const person of personInfo) {
         person.classList.remove('select');
         if (person.textContent.includes(searched.value)) {
            person.className = 'select';
         }
      }
   }
}