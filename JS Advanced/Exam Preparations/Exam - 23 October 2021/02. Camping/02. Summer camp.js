class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.listOfParticipants = [];
        this.priceForTheCamp = {
            child: 150,
            student: 300,
            collegian: 500
        }
    }

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error("Unsuccessful registration at the camp.");
        }

        if (this.listOfParticipants.some(p => p.name === name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (money < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({
            name,
            condition,
            power: 100,
            wins: 0
        });

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        if (!this.listOfParticipants.some(p => p.name === name)) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        const index = this.listOfParticipants.findIndex(p => p.name === name);
        this.listOfParticipants.splice(index);
        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        if (typeOfGame === 'WaterBalloonFights') {
            const player1 = this.listOfParticipants.find(p => p.name === participant1);
            const player2 = this.listOfParticipants.find(p => p.name === participant2);

            if (player1 === undefined || player2 === undefined) {
                throw new Error(`Invalid entered name/s.`);
            }

            if (player1.condition !== player2.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if (player1.power === player2.power) {
                return `There is no winner.`;
            }

            const winner = player1.power > player2.power ? player1 : player2;
            winner.wins++;
            return  `The ${winner.name} is winner in the game ${typeOfGame}.`;
        }

        if (typeOfGame === 'Battleship') {
            const player = this.listOfParticipants.find(n => n.name === participant1)

            if (player === undefined) {
                throw new Error(`Invalid entered name/s.`);
            }

            player.power += 20;
            return `The ${player.name} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString() {
        const participantsAsStr = this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        const participantsToPrint = participantsAsStr.map(p => `${p.name} - ${p.condition} - ${p.power} - ${p.wins}`).join('\n');

        return [
            `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`,
            participantsToPrint
        ].join('\n')
    }
}