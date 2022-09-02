function solve(n, m) {
  let num1 = Number(n);
  let num2 = Number(m);
  let sum = 0;

  for (let i = num1; i <= num2; i++) {
    sum += i;
  }

  console.log(sum);
}

solve("1", "5");
solve("-8", "20");
