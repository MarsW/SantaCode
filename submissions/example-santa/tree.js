function printTree(height) {
    for (let i = 0; i < height; i++) {
        const spaces = ' '.repeat(height - i - 1);
        const stars = '*'.repeat(2 * i + 1);
        console.log(spaces + stars);
    }
    const trunkSpaces = ' '.repeat(height - 1);
    console.log(trunkSpaces + '|');
}

printTree(5);
console.log("\nMerry Christmas! 🎄");

