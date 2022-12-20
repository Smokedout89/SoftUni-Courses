class Textbox {
    constructor(selector, regex) {
        this._value = '';
        this._elements = Array.from(document.querySelectorAll(selector));
        this._invalidSymbols = regex;
    }

    get value() {
        return this._value;
    }

    set value(value) {
        this._value = value;

        for (let i = 0; i < this._elements.length; i++) {
            this._elements[i].value = value;
        }
    }

    get elements() {
        return this._elements;
    }

    isValid() {
        return !this._invalidSymbols.test(this.value);
    }
}