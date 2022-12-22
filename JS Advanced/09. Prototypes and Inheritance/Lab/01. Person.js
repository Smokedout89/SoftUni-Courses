function createPerson(firstName, lastName) {
    const result = {
        firstName,
        lastName,
        fullName: firstName + ' ' + lastName
    };

    Object.defineProperty(result, 'fullName', {
        get() {
            return this.firstName + ' ' + this.lastName;
        },
        set(value) {
            const [first, last] = value.split(' ');

            if (first !== undefined && last !== undefined) {
                this.firstName = first;
                this.lastName = last;
            }
        }
    });

    return result;
}

let person = createPerson("Albert", "Simpson");
console.log(person.fullName); //Albert Simpson
person.firstName = "Simon";
console.log(person.fullName); //Simon Simpson
person.fullName = "Peter";
console.log(person.firstName);  // Simon
console.log(person.lastName);  // Simpson
