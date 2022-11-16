function solve() {
  let text = document.getElementById('text').value;
  let convention = document.getElementById('naming-convention').value;
  let result = '';

  let words = text.split(' ')
  if (convention != 'Camel Case' && convention != 'Pascal Case') {
    return document.getElementById('result').textContent = 'Error!';
  }

  for (let i = 0; i < words.length; i++) {
    words[i] = words[i].toLowerCase();
    debugger;
    if (i != 0 || convention == 'Pascal Case') {
      words[i] = words[i].charAt(0).toUpperCase() + words[i].substring(1);
    }
  }

  result = words.join('');
  document.getElementById('result').textContent = result;
} 