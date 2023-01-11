class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    };

    addPlant(plantName, spaceRequired) {
        if (this.spaceAvailable < spaceRequired) {
            throw new Error('Not enough space in the garden.');
        }

        this.spaceAvailable -= spaceRequired;

        this.plants.push({
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        });

        return `The ${plantName} has been successfully planted in the garden.`;
    };

    ripenPlant(plantName, quantity) {
        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        const currPlant = this.plants.find(p => p.plantName === plantName);

        if (currPlant === undefined) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (currPlant.ripe) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        currPlant.ripe = true;
        currPlant.quantity += quantity;

        return quantity === 1
            ? `${quantity} ${plantName} has successfully ripened.`
            : `${quantity} ${plantName}s have successfully ripened.`;
    };

    harvestPlant(plantName) {
        let plantIndex = this.plants.findIndex(p => p.plantName === plantName);

        if (plantIndex === -1) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        const currPlant = this.plants[plantIndex];

        if (!currPlant.ripe) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.plants.splice(plantIndex, 1);
        this.storage.push({
            plantName,
            quantity: currPlant.quantity
        });

        this.spaceAvailable += currPlant.spaceRequired;

        return `The ${plantName} has been successfully harvested.`;
    };

    generateReport() {
        const plantAsString = this.plants.map(p => p.plantName).sort((a, b) => a.localeCompare(b));
        const plantsRow = `Plants in the garden: ${plantAsString.join(', ')}`;

        const storageAsString = this.storage.map(p => `${p.plantName} (${p.quantity})`);
        let storageRow = '';

        this.storage.length === 0
            ? storageRow = `Plants in storage: The storage is empty.`
            : storageRow = `Plants in storage: ${storageAsString.join(', ')}`

        return [
            `The garden has ${this.spaceAvailable} free space left.`,
            plantsRow,
            storageRow
        ].join('\n');
    };
}