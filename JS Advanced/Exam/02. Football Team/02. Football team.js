class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        for (const player of footballPlayers) {
            let [name, age, playerValue] = player.split('/');
            age = Number(age);
            playerValue = Number(playerValue);

            const currPlayer = this.invitedPlayers.find(p => p.name === name);

            if (currPlayer !== undefined) {
                if (playerValue > currPlayer.playerValue) {
                    currPlayer.playerValue = playerValue;
                }
            } else {
                this.invitedPlayers.push({
                    name,
                    age,
                    playerValue
                });
            }
        }

        let players = this.invitedPlayers.map(n => `${n.name}`);
        return `You successfully invite ${players.join(', ')}.`;
    }

    signContract(selectedPlayer) {
        let [name, playerOffer] = selectedPlayer.split('/');

        playerOffer = Number(playerOffer);
        const currentPlayer = this.invitedPlayers.find(p => p.name === name);

        if (currentPlayer === undefined) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (playerOffer < currentPlayer.playerValue) {
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${currentPlayer.playerValue - playerOffer} million more are needed to sign the contract!`);
        }

        currentPlayer.playerValue = "Bought";
        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }

    ageLimit(name, age) {
        const currentPlayer = this.invitedPlayers.find(p => p.name === name);

        if (currentPlayer === undefined) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (currentPlayer.age < age) {
            const difference = age - currentPlayer.age;

            if (difference < 5) {
                return `${name} will sign a contract for ${difference} years with ${this.clubName} in ${this.country}!`;
            } else {
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        } else {
            return `${name} is above age limit!`;
        }
    }

    transferWindowResult() {
        let players = this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name));
        let playersAsStr = players.map(p => `Player ${p.name}-${p.playerValue}`).join('\n');

        return [
            `Players list:`,
            playersAsStr
        ].join('\n');
    }
}