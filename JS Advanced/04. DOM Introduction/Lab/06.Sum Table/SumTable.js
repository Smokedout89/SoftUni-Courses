function sumTable() {
    let productInfo = document.querySelectorAll('tr td');
    let sum = 0;

    for (let i = 1; i < productInfo.length - 1; i+=2) {
        sum += Number(productInfo[i].textContent);
        console.log(sum);
    }
    
    document.getElementById('sum').textContent = sum;
}