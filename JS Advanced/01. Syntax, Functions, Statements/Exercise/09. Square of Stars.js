function solve(num = 5) {
  let symbol = `* `;

  for (var i = 1; i <= num; i++) {
    console.log(symbol.repeat(num).trim());
  }
}

solve();
solve(1);
solve(2);
solve(7);
