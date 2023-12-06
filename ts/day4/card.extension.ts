import { Card } from "./card.model";

export function readFromLines(lines: string[]): Card[] {
    return lines.map(l => readFromLine(l))
}

function readFromLine(line: string): Card {
    const tmpSplit = line.split(':');
    const idSplit = tmpSplit[0].split(' ');
    const pipeSplit = tmpSplit[1].split('|');

    const card: Card = {
        id: +(idSplit[idSplit.length - 1]), 
        winningNumbers: getListNumbers(pipeSplit[0]), 
        ownNumbers: getListNumbers(pipeSplit[1])
    };
    return card;
}

function getListNumbers(line: string): number[] {
    const REGEX = /\d+/g;

    const numbersRegex = line.match(REGEX);
    let numbers: number[] = []
    numbersRegex?.forEach(n => numbers.push(Number(n)));
    return numbers;
}

export function computeValue(card: Card): number {
    const nbWinning: number = numberOfWinningCards(card);
    return nbWinning == 0 ? 0 : Math.pow(2, Number(nbWinning - 1));
}

export function numberOfWinningCards(card: Card): number {
    return card.ownNumbers.filter(x => card.winningNumbers.includes(x)).length
}