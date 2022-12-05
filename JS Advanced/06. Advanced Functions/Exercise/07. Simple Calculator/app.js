function calculator() {
    let selector1;
    let selector2;
    let result;

    return {
        init,
        add,
        subtract
    }

    function init(s1, s2, res) {
        selector1 = document.querySelector(s1);
        selector2 = document.querySelector(s2);
        result = document.querySelector(res);
    }

    function add() {
        result.value = Number(selector1.value) + Number(selector2.value);
    }

    function subtract() {
        result.value = Number(selector1.value) - Number(selector2.value);
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result'); 