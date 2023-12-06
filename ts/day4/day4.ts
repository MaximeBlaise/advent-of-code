import { getLines } from "../helpers/file.helper";
import { computeValue, numberOfWinningCards, readFromLines } from "./card.extension";
import { Card } from "./card.model";

interface CardDict {
    [key: number]: number;
}

async function main() {
    const lines = getLines(4, false);
    const cards: Card[] = readFromLines(lines);

    // part 1
    const part1sum: number = cards.map(c => computeValue(c)).reduce((sum, current) => sum + current)
    console.log(`Part 1 sum: ${part1sum}`);

    // init part 2
    let nbWinningDict: CardDict = {};
    let userCardsDict: CardDict = {};
    cards.map(c => {
        nbWinningDict[c.id] = numberOfWinningCards(c);
        userCardsDict[c.id] = 1
    });

    // part 2
    cards.map(c => {
        const nbWinning: number = nbWinningDict[c.id];
        for (let index = c.id + 1; index <= c.id + nbWinning; index++) {
            userCardsDict[index] = userCardsDict[index] + userCardsDict[c.id];
        }
    });
    const part2sum = cards.map(c => userCardsDict[c.id]).reduce((sum, current) => sum + current);
    console.log(`Part 2 sum: ${part2sum}`);
}

main();