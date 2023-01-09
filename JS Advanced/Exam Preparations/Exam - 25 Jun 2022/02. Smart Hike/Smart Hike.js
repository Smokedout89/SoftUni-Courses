class SmartHike {
    constructor(username) {
        this.username = username;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }

    addGoal(peak, altitude) {
        if (this.goals[peak] !== undefined) {
            return `${peak} has already been added to your goals`;
        } else {
            this.goals[peak] = altitude;
            return `You have successfully added a new goal - ${peak}`;
        }
    }

    hike(peak, time, difficultyLevel) {
        if (this.goals[peak] === undefined) {
            throw new Error(`${peak} is not in your current goals`);
        }

        if (this.resources === 0) {
            throw new Error("You don't have enough resources to start the hike");
        }

        this.resources -= time * 10;

        if (this.resources < 0) {
            return "You don't have enough resources to complete the hike";
        } else {
            this.listOfHikes.push({
                peak,
                time,
                difficultyLevel
            });

            return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
        }
    }

    rest(time) {
        this.resources += time * 10;

        if (this.resources >= 100) {
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`;
        } else {
            return `You have rested for ${time} hours and gained ${time * 10}% resources`;
        }
    }

    showRecord(criteria) {
        if (this.listOfHikes.length === 0) {
            return `${this.username} has not done any hiking yet`;
        }

        if (criteria === 'hard' || criteria === 'easy') {
            let best = this.listOfHikes.find(h => h.difficultyLevel === criteria);

            if (best === undefined) {
                return `${this.username} has not done any ${criteria} hiking yet`;
            } else {
                return `${this.username}'s best ${criteria} hike is ${best.peak} peak, for ${best.time} hours`;
            }

            // for (const hike of this.listOfHikes) {
            //     if (hike.difficultyLevel === criteria) {
            //         return `${this.username}'s best ${criteria} hike is ${hike.peak} peak, for ${hike.time} hours`;
            //     }
            // }
            // return `${this.username} has not done any ${criteria} hiking yet`;
        }

        if (criteria === 'all') {
            let hikeAsRow = this.listOfHikes.map(h => `${this.username} hiked ${h.peak} for ${h.time} hours`);
            let hikesAsStr = `${hikeAsRow.join('\n')}`;

            return [
                `All hiking records:`,
                hikesAsStr
            ].join(`\n`)

            // let result = "All hiking records:";
            //
            // for (const hike of this.listOfHikes) {
            //     result += `\n${this.username} hiked ${hike.peak} for ${hike.time} hours`;
            // }
            // return result;
        }
    }
}
const user = new SmartHike('Vili');
user.addGoal('Musala', 2925);
user.hike('Musala', 8, 'hard');
user.rest(10);
console.log(user.showRecord('easy'));
user.addGoal('Vihren', 2914);
user.hike('Vihren', 4, 'hard');
console.log(user.showRecord('hard'));
user.addGoal('Rui', 1706);
user.hike('Rui', 3, 'easy');
console.log(user.showRecord('all'));
