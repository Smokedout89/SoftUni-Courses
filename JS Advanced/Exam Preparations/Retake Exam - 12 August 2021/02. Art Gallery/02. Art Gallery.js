class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250
        };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {
        if (!this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())) {
            throw new Error("This article model is not included in this gallery!");
        }

        const article = this.listOfArticles.find(a => a.articleName === articleName);

        if (article === undefined) {
            this.listOfArticles.push({
                articleModel: articleModel.toLowerCase(),
                articleName,
                quantity
            });
        } else if (article.articleModel.toLowerCase() === articleModel.toLowerCase()) {
            article.quantity += quantity;
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.some(n => n.guestName === guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        } else {
            let points = 0;
            if (personality === 'Vip') {
                points = 500;
            } else if (personality === 'Middle') {
                points = 250;
            } else {
                points = 50;
            }

            this.guests.push({
                guestName,
                points,
                purchaseArticle: 0
            });

            return `You have successfully invited ${guestName}!`;
        }
    }

    buyArticle(articleModel, articleName, guestName) {
        const article = this.listOfArticles.find(a => a.articleName === articleName);

        if (article === undefined || article.articleModel.toLowerCase() !== articleModel.toLowerCase()) {
            throw new Error("This article is not found.");
        }

        if (article.quantity === 0) {
            return `The ${articleName} is not available.`;
        }

        const guest = this.guests.find(g => g.guestName === guestName);

        if (guest === undefined) {
            return "This guest is not invited.";
        }

        const price = this.possibleArticles[articleModel.toLowerCase()];

        if (guest.points >= price) {
            guest.points -= price;
            article.quantity--;
            guest.purchaseArticle++;
            return `${guestName} successfully purchased the article worth ${price} points.`;
        } else {
            return "You need to more points to purchase the article.";
        }
    }

    showGalleryInfo(criteria) {
        if (criteria === 'article') {
            const articlesAsStr = this.listOfArticles.map(a => `${a.articleModel} - ${a.articleName} - ${a.quantity}`).join('\n');

            return [
                `Articles information:`,
                articlesAsStr
            ].join('\n');
        }

        if (criteria === 'guest') {
            const guestsAsStr = this.guests.map(g => `${g.guestName} - ${g.purchaseArticle}`).join('\n');
            return [
                `Guests information:`,
                guestsAsStr
            ].join('\n');
        }
    }
}