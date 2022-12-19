class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department){
        let args = [name, salary, position, department];

        if (args.some(x => x === '' || x === 'undefined' || x === null || salary < 0)) {
            throw new Error('Invalid input!');
        }

        let employee = {
            name,
            salary,
            position
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }

        this.departments[department].push(employee);
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    };

    bestDepartment() {
        let bestDepartment = '';
        let maxSalary = 0;

        for (const [key, employees] of Object.entries(this.departments)) {
            let currDepartmentAvgSalary =
                this.departments[key].reduce((avg, e) => avg + e.salary, 0) / employees.length;

            if (currDepartmentAvgSalary > maxSalary) {
                bestDepartment = key;
                maxSalary = currDepartmentAvgSalary;
            }
        }

        if (bestDepartment !== '') {
            this.departments[bestDepartment]
                .sort((a,b) => b.salary - a.salary || a.name.localeCompare(b.name));

            let output = `Best Department is: ${bestDepartment}\n`;
            output += `Average salary: ${maxSalary.toFixed(2)}\n`;

            for (const employee of Object.values(this.departments[bestDepartment])) {
                output += `${employee.name} ${employee.salary} ${employee.position}\n`
            }

            return output.trim();
        }
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());