function solve(month, year) {
  let result = new Date(year, month, 0).getDate();
  console.log(result);
}

solve(1, 2012);
solve(2, 2021);
