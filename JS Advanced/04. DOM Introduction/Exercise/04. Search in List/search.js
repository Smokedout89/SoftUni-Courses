function search() {
   let towns = document.querySelectorAll('ul li');
   let result = document.getElementById('result');
   let searched = document.getElementById('searchText').value;
   let matches = 0;

   for (const town of towns) {
      let text = town.textContent;

      if (text.match(searched)) {
         matches++;
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
      } else {
         town.style.fontWeight = '';
         town.style.textDecoration = '';
      }

   }

   result.textContent = `${matches} matches found`
}