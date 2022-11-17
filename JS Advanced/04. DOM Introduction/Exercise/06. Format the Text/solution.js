function solve() {
  let input = document.getElementById('input').value;
  let output = document.getElementById('output');
  output.innerHTML = '';
  let sentances = input.split('.').filter(s => s.length != 0);

  for (let i = 0; i < sentances.length; i+=3) {
      let result = [];
      for (let j = 0; j < 3; j++) {
        if (sentances[i + j]) {
          result.push(sentances[i + j]);
        }
      }

      let text = result.join('. ') + '.';
      output.innerHTML += `<p>${text}</p>`;
  }
}