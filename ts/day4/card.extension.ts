import { Card } from "./card.model";

export function readFromLines(lines: string[]): Card[] {
    return lines.map(l => readFromLine(l))
}

function readFromLine(line: string): Card {
    var tmpSplit = line.split(':');

    var idSplit = tmpSplit[0].split(' ');
    var pipeSplit = tmpSplit[1].split('|');

    let card: Card = {
        id: +(idSplit[idSplit.length - 1]), 
        winningNumbers: getListNumbers(pipeSplit[0]), 
        ownNumbers: getListNumbers(pipeSplit[1])
    };
    return card;
}

function getListNumbers(line: string): number[] {
    const REGEX = /\d+/g;

    let numbersRegex = line.match(REGEX);
    let numbers: number[] = []
    numbersRegex?.forEach(n => numbers.push(Number(n)));
    return numbers;
}

export function computeValue(card: Card): number {
    let nbWinning: number = numberOfWinningCards(card);
    return nbWinning == 0 ? 0 : Math.pow(2, Number(nbWinning - 1));
}

export function numberOfWinningCards(card: Card): number {
    return card.ownNumbers.filter(x => card.winningNumbers.includes(x)).length
}