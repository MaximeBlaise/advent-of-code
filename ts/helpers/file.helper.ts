import * as fs from "fs";

export function getLines(day: number, isSample: boolean) {
    const suffix: string = isSample ? 'sample': 'input';
    const path: string = `inputs/day${day}_${suffix}.txt`;
    return getLinesFromPath(path);
}

export function getLinesFromPath(path: string) {
    console.log(`Get lines from ${path}`);
    return fs.readFileSync(path, {encoding: "utf-8"}).split('\n');
}
